using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository.Repositories.Interfaces;
using Service.DTOs.UI.Account;
using Service.Helpers;
using Service.Helpers.Account;
using Service.Helpers.Constants;
using Service.Helpers.Enums;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;
        private readonly IPhotoService _photoService;
        private readonly IUserImageRepository _userImageRepository;

        public AccountService(UserManager<AppUser> userManager,
                              RoleManager<IdentityRole> roleManager,
                              SignInManager<AppUser> signInManager,
                              IMapper mapper,
                              IOptions<JwtSettings> jwtSettings,
                              IPhotoService photoService,
                              IUserImageRepository userImageRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _photoService = photoService;
            _userImageRepository = userImageRepository;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<RegisterResponse> SignUpAsync(RegisterDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var user = _mapper.Map<AppUser>(model);

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var isEmailTaken = result.Errors.Any(m => m.Code == "DuplicateEmail");
                var isUsernameTaken = result.Errors.Any(m => m.Code == "DuplicateUserName");

                if (isEmailTaken && isUsernameTaken)
                {
                    return new RegisterResponse
                    {
                        Success = false,
                        IsEmailTaken = true,
                        IsUsernameTaken = true,
                        Errors = result.Errors.Select(m => m.Description)
                    };
                }

                if (isEmailTaken)
                {
                    return new RegisterResponse
                    {
                        Success = false,
                        IsEmailTaken = true,
                        Errors = result.Errors.Select(m => m.Description)
                    };
                }

                if (isUsernameTaken)
                {
                    return new RegisterResponse
                    {
                        Success = false,
                        IsUsernameTaken = true,
                        Errors = result.Errors.Select(m => m.Description)
                    };
                }

                return new RegisterResponse
                {
                    Success = false,
                    Errors = result.Errors.Select(m => m.Description)
                };
            }

            await _userManager.AddToRoleAsync(user, Roles.Member.ToString());

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return new RegisterResponse
            {
                Success = true,
                Errors = null,
                UserId = user.Id,
                ConfirmationToken = token
            };
        }

        public async Task<LoginResponse> SignInAsync(LoginDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var user = await _userManager.Users
                .Where(u => u.Email == model.EmailOrUserName)
                .Include(u => u.UserImage)
                .FirstOrDefaultAsync() ??
                       await _userManager.Users
                .Where(u => u.UserName == model.EmailOrUserName)
                .Include(u => u.UserImage)
                .FirstOrDefaultAsync();


            if (user is null)
            {
                return new LoginResponse
                {
                    Success = false,
                    Error = "Login failed",
                    Token = null
                };
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                return new LoginResponse
                {
                    Success = false,
                    Error = "Login failed",
                    Token = null
                };
            }

            List<string> userRoles = (List<string>)await _userManager.GetRolesAsync(user);

            string token = GenerateJwtToken(user.UserName, user.Id, userRoles);

            return new LoginResponse
            {
                Success = true,
                Error = null,
                Token = token,
                ProfilePicture = user.UserImage.Url
            };
        }

        public async Task<UserImageDto> EditProfilePictureAsync(string userId, UserImageEditDto model)
        {
            ArgumentNullException.ThrowIfNull(userId);
            ArgumentNullException.ThrowIfNull(model);

            var existingUserImage = await _userImageRepository.GetFirstWithExpressionAsync(ui => ui.UserId == userId);
            if (existingUserImage.PublicId != "default-profile-pic")
            {
                await _photoService.DeletePhoto(existingUserImage.PublicId);
            }

            await _userImageRepository.DeleteAsync(existingUserImage);

            var uploadResult = await _photoService.AddPhoto(model.ProfilePicture);

            var newUserImage = new UserImage
            {
                Url = uploadResult.SecureUrl.ToString(),
                PublicId = uploadResult.PublicId,
                UserId = userId
            };
            await _userImageRepository.CreateAsync(newUserImage);

            return new UserImageDto { Url = uploadResult.SecureUrl.ToString() };
        }


        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _userManager.Users.ToListAsync());
        }

        public async Task<UserDto> GetByUserIdAsync(string userId)
        {
            ArgumentNullException.ThrowIfNull(userId);

            var user = await _userManager.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UserImage)
                .FirstOrDefaultAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByUserNameAsync(string userName)
        {
            ArgumentNullException.ThrowIfNull(userName);

            var existUser = await _userManager.FindByNameAsync(userName);

            return existUser is null
                ? throw new NotFoundException($"{userName} - user not found")
                : _mapper.Map<UserDto>(existUser);
        }

        public async Task ConfirmEmailAsync(string userId, string token)
        {
            ArgumentNullException.ThrowIfNull(userId);
            ArgumentNullException.ThrowIfNull(token);

            var user = await _userManager.FindByIdAsync(userId) ?? throw new NotFoundException(ResponseMessages.NotFound);
            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                await _userImageRepository.CreateAsync(new UserImage
                {
                    Url = "https://res.cloudinary.com/duta72kmn/image/upload/v1723573659/urglfp6i03xtotugts2s.png",
                    PublicId = "default-profile-pic",
                    UserId = user.Id
                });
            }
        }

        public async Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var user = await _userManager.FindByEmailAsync(model.EmailOrUserName) ??
                       await _userManager.FindByNameAsync(model.EmailOrUserName);

            if (user is null || !await _userManager.IsEmailConfirmedAsync(user))
            {
                return new ForgotPasswordResponse
                {
                    Success = false,
                };
            }

            return new ForgotPasswordResponse
            {
                Success = true,
                UserId = user.Id,
                Email = user.Email,
                PasswordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user)
            };
        }

        public async Task ResetPasswordAsync(PasswordResetDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var user = await _userManager.FindByIdAsync(model.UserId) ?? throw new NotFoundException(ResponseMessages.NotFound);

            bool isSamePassword = await _userManager.CheckPasswordAsync(user, model.NewPassword);

            if (isSamePassword)
            {
                throw new BadRequestException(ResponseMessages.SamePassword);
            }

            await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
        }

        public async Task<EditResponse> EditUserAsync(string userId, UserEditDto model)
        {
            ArgumentNullException.ThrowIfNull(model);
            ArgumentNullException.ThrowIfNull(userId);

            var user = await _userManager.FindByIdAsync(userId) ?? throw new NotFoundException(ResponseMessages.NotFound);

            var result = await _userManager.UpdateAsync(_mapper.Map(model, user));

            if (!result.Succeeded)
            {
                return new EditResponse
                {
                    Success = false,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }

            List<string> userRoles = (List<string>)await _userManager.GetRolesAsync(user);

            string token = GenerateJwtToken(user.UserName, user.Id, userRoles);

            return new EditResponse
            {
                Success = true,
                Token = token
            };
        }

        public async Task<EditResponse> EditPasswordAsync(string userId, PasswordEditDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var user = await _userManager.FindByIdAsync(userId) ?? throw new NotFoundException(ResponseMessages.NotFound);

            bool isSamePassword = await _userManager.CheckPasswordAsync(user, model.NewPassword);

            if (isSamePassword)
            {
                throw new BadRequestException(ResponseMessages.SamePassword);
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return new EditResponse
                {
                    Success = false,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }

            List<string> userRoles = (List<string>)await _userManager.GetRolesAsync(user);

            string token = GenerateJwtToken(user.UserName, user.Id, userRoles);

            return new EditResponse
            {
                Success = true,
                Token = token
            };
        }

        public async Task CreateRoleAsync()
        {
            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }
            }
        }

        private string GenerateJwtToken(string username, string userId, List<string> roles)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, username),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(ClaimTypes.NameIdentifier, userId),
                new(ClaimTypes.Name, username)
            };

            roles.ForEach(role =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpireDays));

            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
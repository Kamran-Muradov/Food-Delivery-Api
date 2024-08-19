using Service.DTOs.Account;
using Service.Helpers;
using Service.Helpers.Account;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterResponse> SignUpAsync(RegisterDto model);
        Task<LoginResponse> SignInAsync(LoginDto model);
        Task EditUserRolesAsync(string userId, UserRoleEditDto model);
        Task<IEnumerable<UserRoleDto>> GetUserRoles(string userId);
        Task<UserDetailDto> GetUserDetailAsync(string userId);
        Task<UserImageDto> EditProfilePictureAsync(string userId, UserImageEditDto model);
        Task<PaginationResponse<UserDto>> GetUsersPaginateAsync(int? page, int? take);
        Task<UserDto> GetUserByIdAsync(string userId);
        Task<UserDto> GetUserByUserNameAsync(string userName);
        Task ConfirmEmailAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordDto model);
        Task ResetPasswordAsync(PasswordResetDto model);
        Task<EditResponse> EditUserAsync(string userId, UserEditDto model);
        Task<EditResponse> EditPasswordAsync(string userId, PasswordEditDto model);
        Task CreateRoleAsync();
    }
}

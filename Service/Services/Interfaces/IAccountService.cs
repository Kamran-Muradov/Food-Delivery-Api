using Microsoft.AspNetCore.Http;
using Service.DTOs.UI.Account;
using Service.Helpers.Account;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterResponse> SignUpAsync(RegisterDto model);
        Task<LoginResponse> SignInAsync(LoginDto model);
        Task<UserImageDto> EditProfilePictureAsync(string userId, UserImageEditDto model);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetByUserIdAsync(string userId);
        Task<UserDto> GetUserByUserNameAsync(string userName);
        Task ConfirmEmailAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordDto model);
        Task ResetPasswordAsync(PasswordResetDto model);
        Task<EditResponse> EditUserAsync(string userId, UserEditDto model);
        Task<EditResponse> EditPasswordAsync(string userId, PasswordEditDto model);
        Task CreateRoleAsync();
    }
}

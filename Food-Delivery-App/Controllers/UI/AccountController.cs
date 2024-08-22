using System.Security.Claims;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Account;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.UI
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] RegisterDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _accountService.SignUpAsync(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] LoginDto request)
        {
            return Ok(await _accountService.SignInAsync(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById([FromQuery] string userId)
        {
            return Ok(await _accountService.GetUserByIdAsync(userId));
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            await _accountService.ConfirmEmailAsync(userId, token);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto request)
        {
            return Ok(await _accountService.ForgotPasswordAsync(request));
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] PasswordResetDto request)
        {
            await _accountService.ResetPasswordAsync(request);
            return Ok();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditUser([FromQuery] string userId, [FromBody] UserEditDto request)
        {
            return Ok(await _accountService.EditUserAsync(userId, request));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditPassword([FromQuery] string userId, [FromBody] PasswordEditDto request)
        {
            return Ok(await _accountService.EditPasswordAsync(userId, request));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditProfilePicture([FromQuery] string userId,
                                                            [FromForm] UserImageEditDto request)
        {
            if (request.ProfilePicture.Length / 1024 > 2048) return Conflict(new { Message = "File size cannot exceed 2Mb" });
            if (!request.ProfilePicture.ContentType.Contains("image/")) return Conflict(new { Message = "File must be image type" });

            return Ok(await _accountService.EditProfilePictureAsync(userId, request));
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteProfilePicture([FromQuery] string userId)
        {
            return Ok(await _accountService.DeleteProfilePictureAsync(userId));
        }
    }
}

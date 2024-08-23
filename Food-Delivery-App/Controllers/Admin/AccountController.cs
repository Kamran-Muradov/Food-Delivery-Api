using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Account;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.Admin
{
    [Authorize(Policy = "RequireSuperAdminRole")]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersPaginate([FromQuery] int page = 1, [FromQuery] int take = 5, [FromQuery] string? searchText = null)
        {
            return Ok(await _accountService.GetUsersPaginateAsync(page, take, searchText));
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByUserName([FromQuery] string userName)
        {
            return Ok(await _accountService.GetUserByUserNameAsync(userName));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoles()
        {
            await _accountService.CreateRoleAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleToUser([FromQuery] string userId, [FromBody] UserRoleEditDto request)
        {
            await _accountService.EditUserRolesAsync(userId, request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles([FromQuery] string userId)
        {
            return Ok(await _accountService.GetUserRoles(userId));
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDetail([FromQuery] string userId)
        {
            return Ok(await _accountService.GetUserDetailAsync(userId));
        }
    }
}

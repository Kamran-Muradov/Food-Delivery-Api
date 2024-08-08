using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.UI.Checkouts;
using Service.Helpers.Constants;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.UI
{
    [Authorize]
    public class CheckoutController : BaseController
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CheckoutCreateDto request)
        {
            await _checkoutService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), new { response = ResponseMessages.CreateSuccess });
        }

        [HttpPost]
        public async Task<IActionResult> CreateByUserId([FromQuery] string userId)
        {
            await _checkoutService.CreateByUserIdAsync(userId);
            return CreatedAtAction(nameof(Create), new { response = ResponseMessages.CreateSuccess });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByUserId([FromQuery] string userId)
        {
            return Ok(await _checkoutService.GetAllByUserIdAsync(userId));
        }
    }
}

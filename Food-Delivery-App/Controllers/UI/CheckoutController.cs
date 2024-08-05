using Microsoft.AspNetCore.Mvc;
using Service.DTOs.UI.Checkouts;
using Service.Helpers.Constants;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.UI
{
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _checkoutService.GetAllAsync());
        }
    }
}

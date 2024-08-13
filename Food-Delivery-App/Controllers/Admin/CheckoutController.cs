using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Checkouts;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.Admin
{
    public class CheckoutController : BaseController
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaginateDatas([FromQuery] int page = 1, [FromQuery] int take = 5)
        {
            return Ok(await _checkoutService.GetPaginateAsync(page, take));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] CheckoutEditDto request)
        {
            await _checkoutService.EditAsync(id, request);
            return Ok();
        }
    }
}

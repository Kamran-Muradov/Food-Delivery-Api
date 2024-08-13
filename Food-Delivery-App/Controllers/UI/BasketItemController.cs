using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Categories;
using Service.DTOs.UI.BasketItems;
using Service.Helpers.Constants;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.UI
{
    public class BasketItemController : BaseController
    {
        private readonly IBasketItemService _basketItemService;

        public BasketItemController(IBasketItemService basketItemService)
        {
            _basketItemService = basketItemService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BasketItemCreateDto request)
        {
            var isDifferentRestaurant = await _basketItemService.IsDifferentRestaurantAsync(request.UserId, request.MenuId);

            if (isDifferentRestaurant) return Conflict(new { Error = "There is basket items for this user for different restaurant.Please reset exist basket first" });

            await _basketItemService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), new { response = ResponseMessages.CreateSuccess });
        }

        [HttpPost]
        public async Task<IActionResult> Reset([FromBody] BasketItemCreateDto request)
        {
            await _basketItemService.ResetAsync(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByUserId([FromQuery] string userId)
        {
            return Ok(await _basketItemService.GetAllByUserIdAsync(userId));
        }

        [HttpPut]
        public async Task<IActionResult> ChangeCount([FromBody] BasketCountDto request)
        {
            await _basketItemService.ChangeCountAsync(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string userId, [FromQuery] int menuId)
        {
            await _basketItemService.DeleteAsync(userId, menuId);
            return Ok();
        }
    }
}

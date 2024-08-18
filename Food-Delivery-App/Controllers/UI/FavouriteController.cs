using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.UI.Favourites;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.UI
{
    [Authorize]
    public class FavouriteController : BaseController
    {
        private readonly IFavouriteService _favouriteService;

        public FavouriteController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FavouriteCreateDto request)
        {
            await _favouriteService.CreateAsync(request);

            var createdFavourite = await _favouriteService.GetFirstWithExpressionAsync(f => f.UserId == request.UserId && f.RestaurantId == request.RestaurantId);
            return CreatedAtAction(nameof(Create), createdFavourite.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByUserId([FromQuery] string userId)
        {
            return Ok(await _favouriteService.GetAllByUserIdAsync(userId));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string userId, [FromQuery] int restaurantId)
        {
            await _favouriteService.DeleteAsync(userId, restaurantId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> IsFavourite([FromQuery] string userId, [FromQuery] int restaurantId)
        {
            var existFavourite = await _favouriteService.GetFirstWithExpressionAsync(f => f.UserId == userId && f.RestaurantId == restaurantId);
            return Ok(existFavourite != null);
        }
    }
}

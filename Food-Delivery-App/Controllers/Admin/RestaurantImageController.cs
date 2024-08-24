using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.Admin
{
    public class RestaurantImageController : BaseController
    {
        private readonly IRestaurantImageService _restaurantImageService;

        public RestaurantImageController(IRestaurantImageService restaurantImageService)
        {
            _restaurantImageService = restaurantImageService;
        }

        [HttpGet("{restaurantId:int}")]
        public async Task<IActionResult> GetAllByRestaurantId([FromRoute] int restaurantId)
        {
            return Ok(await _restaurantImageService.GetAllByRestaurantId(restaurantId));
        }
    }
}

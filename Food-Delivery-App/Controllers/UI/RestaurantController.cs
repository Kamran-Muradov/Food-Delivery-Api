using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.UI
{
    public class RestaurantController : BaseController
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _restaurantService.GetAllWithMainImageAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string searchText)
        {
            return Ok(await _restaurantService.SearchByNameAndCategory(searchText));
        }
    }
}

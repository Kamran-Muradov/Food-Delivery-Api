using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.UI
{
    public class MenuController : BaseController
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] int restaurantId, [FromQuery] string? searchText = null)
        {
            return Ok(await _menuService.SearchByRestaurantId(restaurantId, searchText));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _menuService.GetByIdAsync(id));
        }
    }
}

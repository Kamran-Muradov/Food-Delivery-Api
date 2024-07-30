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
        public async Task<IActionResult> Search([FromQuery] string searchText)
        {
            return Ok(await _menuService.SearchByNameAndCategory(searchText));
        }
    }
}

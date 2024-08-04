using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.UI
{
    public class MenuVariantController : BaseController
    {
        private readonly IMenuVariantService _menuVariantService;

        public MenuVariantController(IMenuVariantService menuVariantService)
        {
            _menuVariantService = menuVariantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByMenuId([FromQuery] int menuId)
        {
            return Ok(await _menuVariantService.GetAllByMenuIdGroupedAsync(menuId));
        }
    }
}

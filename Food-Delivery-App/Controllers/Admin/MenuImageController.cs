using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.Admin
{
    public class MenuImageController : BaseController
    {
        private readonly IMenuImageService _menuImageService;

        public MenuImageController(IMenuImageService menuImageService)
        {
            _menuImageService = menuImageService;
        }

        [HttpGet("{menuId:int}")]
        public async Task<IActionResult> GetByMenuId([FromRoute] int? menuId)
        {
            return Ok(await _menuImageService.GetByMenuId(menuId));
        }
    }
}

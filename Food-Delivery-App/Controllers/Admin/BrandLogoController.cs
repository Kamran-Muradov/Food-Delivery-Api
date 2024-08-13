using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.Admin
{
    public class BrandLogoController : BaseController
    {
        private readonly IBrandLogoService _brandLogoService;

        public BrandLogoController(IBrandLogoService brandLogoService)
        {
            _brandLogoService = brandLogoService;
        }

        [HttpGet("{brandId:int}")]
        public async Task<IActionResult> GetByBrandId([FromRoute] int brandId)
        {
            return Ok(await _brandLogoService.GetByBrandIdAsync(brandId));
        }
    }
}

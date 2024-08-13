using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.UI
{
    public class BrandController : BaseController
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _brandService.GetAllAsync());
        }
    }
}

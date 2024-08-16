using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.Admin
{
    public class AboutImageController : BaseController
    {
        private readonly IAboutImageService _aboutImageService;

        public AboutImageController(IAboutImageService aboutImageService)
        {
            _aboutImageService = aboutImageService;
        }

        [HttpGet("{aboutId:int}")]
        public async Task<IActionResult> GetByAboutId([FromRoute] int aboutId)
        {
            return Ok(await _aboutImageService.GetByAboutIdAsync(aboutId));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.Admin
{
    public class SliderImageController : BaseController
    {
        private readonly ISliderImageService _sliderImageService;

        public SliderImageController(ISliderImageService sliderImageService)
        {
            _sliderImageService = sliderImageService;
        }

        [HttpGet("{sliderId:int}")]
        public async Task<IActionResult> GetBySliderId([FromRoute] int sliderId)
        {
            return Ok(await _sliderImageService.GetBySliderIdAsync(sliderId));
        }
    }
}

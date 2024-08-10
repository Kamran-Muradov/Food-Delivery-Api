using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.UI
{
    public class SliderController : BaseController
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _sliderService.GetAllAsync());
        }
    }
}

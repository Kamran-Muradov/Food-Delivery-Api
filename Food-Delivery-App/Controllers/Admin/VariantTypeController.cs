using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.Admin
{
    public class VariantTypeController : BaseController
    {
        private readonly IVariantTypeService _variantTypeService;

        public VariantTypeController(IVariantTypeService variantTypeService)
        {
            _variantTypeService = variantTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForSelect([FromQuery] int? excludeId = null)
        {
            return Ok(await _variantTypeService.GetAllForSelectAsync(excludeId));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.Admin
{
    public class CategoryImageController : BaseController
    {
        private readonly ICategoryImageService _categoryImageService;

        public CategoryImageController(ICategoryImageService categoryImageService)
        {
            _categoryImageService = categoryImageService;
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetByCategoryId([FromRoute] int categoryId)
        {
            return Ok(await _categoryImageService.GetByCategoryIdAsync(categoryId));
        }
    }
}

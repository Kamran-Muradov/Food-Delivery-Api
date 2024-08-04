using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.Admin
{
    public class TagImageController : BaseController
    {
        private readonly ITagImageService _tagImageService;

        public TagImageController(ITagImageService tagImageService)
        {
            _tagImageService = tagImageService;
        }

        [HttpGet("{tagId:int}")]
        public async Task<IActionResult> GetByTagId([FromRoute] int tagId)
        {
            return Ok(await _tagImageService.GetByTagIdAsync(tagId));
        }
    }
}

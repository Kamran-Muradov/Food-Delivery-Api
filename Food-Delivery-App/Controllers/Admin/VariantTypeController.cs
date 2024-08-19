using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.VariantTypes;
using Service.Helpers.Constants;
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

        [HttpPost]
        [Authorize(Policy = "RequireSuperAdminRole")]
        public async Task<IActionResult> Create([FromBody] VariantTypeCreateDto request)
        {
            if (await _variantTypeService.ExistAsync(request.Name))
            {
                return Conflict(new { Message = ResponseMessages.ExistData });
            }

            await _variantTypeService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), new { response = ResponseMessages.CreateSuccess });
        }

        [HttpGet]
        public async Task<IActionResult> GetPaginateDatas([FromQuery] int page = 1, [FromQuery] int take = 5)
        {
            return Ok(await _variantTypeService.GetPaginateAsync(page, take));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForSelect([FromQuery] int? excludeId = null)
        {
            return Ok(await _variantTypeService.GetAllForSelectAsync(excludeId));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int? id)
        {
            return Ok(await _variantTypeService.GetByIdAsync(id));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] VariantTypeEditDto request)
        {
            if (await _variantTypeService.ExistAsync(request.Name, id))
            {
                return Conflict(new { Message = ResponseMessages.ExistData });
            }

            await _variantTypeService.EditAsync(id, request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _variantTypeService.DeleteAsync(id);
            return Ok();
        }
    }
}

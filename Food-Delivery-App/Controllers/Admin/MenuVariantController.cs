using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Ingredients;
using Service.DTOs.Admin.MenuVariants;
using Service.Helpers.Constants;
using Service.Services;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.Admin
{
    public class MenuVariantController : BaseController
    {
        private readonly IMenuVariantService _menuVariantService;

        public MenuVariantController(IMenuVariantService menuVariantService)
        {
            _menuVariantService = menuVariantService;
        }

        [HttpPost]
        [Authorize(Policy = "RequireSuperAdminRole")]
        public async Task<IActionResult> Create([FromBody] MenuVariantCreateDto request)
        {
            if (await _menuVariantService.ExistAsync(request.MenuId, request.VariantTypeId, request.Option))
            {
                return Conflict(new { Message = ResponseMessages.ExistData });
            }

            await _menuVariantService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), new { response = ResponseMessages.CreateSuccess });
        }


        [HttpGet]
        public async Task<IActionResult> GetPaginateDatas([FromQuery] int page = 1, [FromQuery] int take = 5)
        {
            return Ok(await _menuVariantService.GetPaginateAsync(page, take));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int? id)
        {
            return Ok(await _menuVariantService.GetByIdAsync(id));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] MenuVariantEditDto request)
        {
            if (await _menuVariantService.ExistAsync(request.MenuId, request.VariantTypeId, request.Option, id))
            {
                return Conflict(new { Message = ResponseMessages.ExistData });
            }

            await _menuVariantService.EditAsync(id, request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _menuVariantService.DeleteAsync(id);
            return Ok();
        }
    }
}

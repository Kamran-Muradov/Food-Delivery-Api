using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Ingredients;
using Service.Helpers.Constants;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.Admin
{
    public class IngredientController : BaseController
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpPost]
        [Authorize(Policy = "RequireSuperAdminRole")]
        public async Task<IActionResult> Create([FromBody] IngredientCreateDto request)
        {
            if (await _ingredientService.ExistAsync(request.Name))
            {
                return Conflict(new { Message = ResponseMessages.ExistData });
            }

            await _ingredientService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), new { response = ResponseMessages.CreateSuccess });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ingredientService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetPaginateDatas([FromQuery] int page = 1, [FromQuery] int take = 5)
        {
            return Ok(await _ingredientService.GetPaginateAsync(page, take));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForSelect([FromQuery] int? excludeId = null)
        {
            return Ok(await _ingredientService.GetAllForSelectAsync(excludeId));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int? id)
        {
            return Ok(await _ingredientService.GetByIdAsync(id));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] IngredientEditDto request)
        {
            if (await _ingredientService.ExistAsync(request.Name, id))
            {
                return Conflict(new { Message = ResponseMessages.ExistData });
            }

            await _ingredientService.EditAsync(id, request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _ingredientService.DeleteAsync(id);
            return Ok();
        }
    }
}

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
        public async Task<IActionResult> Create([FromBody] IngredientCreateDto request)
        {
            await _ingredientService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), new { response = ResponseMessages.CreateSuccess });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ingredientService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int? id)
        {
            return Ok(_ingredientService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] IngredientEditDto request)
        {
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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Cities;
using Service.DTOs.Admin.Countries;
using Service.Helpers.Constants;
using Service.Services;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.Admin
{
    public class CityController : BaseController
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost]
        [Authorize(Policy = "RequireSuperAdminRole")]
        public async Task<IActionResult> Create([FromBody] CityCreateDto request)
        {
            if (await _cityService.ExistAsync(request.Name))
            {
                return Conflict(new { Message = ResponseMessages.ExistData });
            }

            await _cityService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), new { response = ResponseMessages.CreateSuccess });
        }

        [HttpGet]
        public async Task<IActionResult> GetPaginateDatas([FromQuery] int page = 1, [FromQuery] int take = 5)
        {
            return Ok(await _cityService.GetPaginateAsync(page, take));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForSelect([FromQuery] int? excludeId = null)
        {
            return Ok(await _cityService.GetAllForSelectAsync(excludeId));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int? id)
        {
            return Ok(await _cityService.GetByIdAsync(id));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] CityEditDto request)
        {
            if (await _cityService.ExistAsync(request.Name, id))
            {
                return Conflict(new { Message = ResponseMessages.ExistData });
            }

            await _cityService.EditAsync(id, request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _cityService.DeleteAsync(id);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Countries;
using Service.Helpers.Constants;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.Admin
{
    public class CountryController : BaseController
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost]
        [Authorize(Policy = "RequireSuperAdminRole")]
        public async Task<IActionResult> Create([FromBody] CountryCreateDto request)
        {
            if (await _countryService.ExistAsync(request.Name))
            {
                return Conflict(new { Message = ResponseMessages.ExistData });
            }

            await _countryService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), new { response = ResponseMessages.CreateSuccess });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _countryService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetPaginateDatas([FromQuery] int page = 1, [FromQuery] int take = 5)
        {
            return Ok(await _countryService.GetPaginateAsync(page, take));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForSelect([FromQuery] int? excludeId = null)
        {
            return Ok(await _countryService.GetAllForSelectAsync(excludeId));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int? id)
        {
            return Ok(await _countryService.GetByIdAsync(id));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] CountryEditDto request)
        {
            if (await _countryService.ExistAsync(request.Name, id))
            {
                return Conflict(new { Message = ResponseMessages.ExistData });
            }

            await _countryService.EditAsync(id, request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _countryService.DeleteAsync(id);
            return Ok();
        }
    }
}

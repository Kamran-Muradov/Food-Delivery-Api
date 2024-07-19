using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Service.DTOs.Admin.Restaurants;
using Service.Helpers.Constants;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.Admin
{
    public class RestaurantController : BaseController
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] RestaurantCreateDto request)
        {
            await _restaurantService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), new { response = ResponseMessages.CreateSuccess });
        }

        [HttpGet]
        public async Task<IActionResult> GetPaginateDatas([FromQuery] int page = 1, [FromQuery] int take = 5)
        {
            return Ok(await _restaurantService.GetPaginateAsync(page, take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int? id)
        {
            return Ok(await _restaurantService.GetByIdDetailAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] RestaurantEditDto request)
        {
            await _restaurantService.EditAsync(id, request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _restaurantService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SetMainImage([FromBody] MainAndDeleteImageDto request)
        {
            await _restaurantService.SetMainImageAsync(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage([FromBody] MainAndDeleteImageDto request)
        {
            await _restaurantService.DeleteImageAsync(request);
            return Ok();
        }
    }
}

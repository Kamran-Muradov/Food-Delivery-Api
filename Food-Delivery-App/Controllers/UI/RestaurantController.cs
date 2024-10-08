﻿using Microsoft.AspNetCore.Mvc;
using Service.DTOs.UI.Restaurants;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.UI
{
    public class RestaurantController : BaseController
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _restaurantService.GetAllWithImagesAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByTagId([FromQuery] int tagId)
        {
            return Ok(await _restaurantService.GetAllByTagIdAsync(tagId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByBrandId([FromQuery] int brandId)
        {
            return Ok(await _restaurantService.GetAllByBrandIdAsync(brandId));
        }

        [HttpPost]
        public async Task<IActionResult> GetAllFiltered([FromBody] RestaurantFilterDto request)
        {
            return Ok(await _restaurantService.GetAllFilteredAsync(request));
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string searchText)
        {
            return Ok(await _restaurantService.SearchByNameAndCategory(searchText));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int? id)
        {
            return Ok(await _restaurantService.GetByIdAsync(id));
        }
    }
}

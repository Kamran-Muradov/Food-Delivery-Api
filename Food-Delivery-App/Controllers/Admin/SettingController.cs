using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Settings;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.Admin
{
    public class SettingController : BaseController
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _settingService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            return Ok(await _settingService.GetByIdAsync(id));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] SettingEditDto request)
        {
            await _settingService.EditAsync(id, request);
            return Ok();
        } 
    }
}

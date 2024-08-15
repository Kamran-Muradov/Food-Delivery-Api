using Microsoft.AspNetCore.Mvc;
using Service.DTOs.UI.Contacts;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.UI
{
    public class ContactController : BaseController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactCreateDto request)
        {
            await _contactService.CreateAsync(request);
            return Ok();
        }
    }
}

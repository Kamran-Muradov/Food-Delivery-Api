using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.UI.Payment;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.UI
{
    [Authorize]
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCheckoutSession([FromBody] PaymentDto request)
        {
            return Ok(await _paymentService.CreateCheckoutSessionAsync(request));
        }

        [HttpGet]
        public IActionResult CheckPaymentStatus([FromQuery] string sessionId)
        {
            var isPaymentComplete = _paymentService.CheckPaymentStatus(sessionId);

            if (isPaymentComplete) return Ok();

            return BadRequest();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.UI.PromoCodes;
using Service.Services.Interfaces;

namespace Food_Delivery_App.Controllers.UI
{
    public class PromoCodeController : BaseController
    {
        private readonly IPromoCodeService _promoCodeService;

        public PromoCodeController(IPromoCodeService promoCodeService)
        {
            _promoCodeService = promoCodeService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ApplyToBasket([FromBody] UserPromoCodeDto request)
        {
            return Ok(await _promoCodeService.ApplyToBasketAsync(request));
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserPromoCode([FromQuery] string userId)
        {
            await _promoCodeService.DeleteUserPromoCodeAsync(userId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActive()
        {
            return Ok(await _promoCodeService.GetAllWithExpressionAsync(pc => pc.ExpiryDate > DateTime.Now && pc.IsActive));
        }
    }
}

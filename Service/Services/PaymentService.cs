using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Service.DTOs.UI.Payment;
using Service.Helpers;
using Service.Services.Interfaces;
using Stripe.Checkout;

namespace Service.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly StripeSettings _stripeSettings;
        private readonly IBasketItemService _basketItemService;
        private readonly UserManager<AppUser> _userManager;

        public PaymentService(IOptions<StripeSettings> stripeSettings,
                              IBasketItemService basketItemService,
                              UserManager<AppUser> userManager)
        {
            _basketItemService = basketItemService;
            _userManager = userManager;
            _stripeSettings = stripeSettings.Value;
        }

        public async Task<PaymentResponse> CreateCheckoutSessionAsync(PaymentDto model)
        {
            const string currency = "usd";
            var successUrl = model.SuccessUrl;
            var cancelUrl = model.CancelUrl;
            var basketItems = await _basketItemService.GetAllByUserIdAsync(model.UserId);
            var user = await _userManager.FindByIdAsync(model.UserId);

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>(),
                SuccessUrl = successUrl + "?sessionId={CHECKOUT_SESSION_ID}",
                CancelUrl = cancelUrl,
                Mode = "payment",
                CustomerEmail = user.Email
            };

            foreach (var item in basketItems)
            {
                var sessionListItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmountDecimal = item.DiscountPrice != null ? item.DiscountPrice / item.Count * 100 : item.Price / item.Count * 100,
                        Currency = currency,
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Name,
                            Images = new List<string> { item.Image }
                        }
                    },
                    Quantity = item.Count
                };

                options.LineItems.Add(sessionListItem);
            }

            var deliveryFeeItem = new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = basketItems.First().DeliveryFee * 100,
                    Currency = currency,
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = "Delivery Fee"
                    }
                },
                Quantity = 1
            };
            options.LineItems.Add(deliveryFeeItem);

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            return new PaymentResponse { SessionUrl = session.Url };
        }

        public bool CheckPaymentStatus(string sessionId)
        {
            var service = new SessionService();
            var session = service.Get(sessionId);

            return session.Status == "complete";
        }
    }
}

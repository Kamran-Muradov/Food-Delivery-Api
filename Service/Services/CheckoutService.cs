using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.UI.BasketItems;
using Service.DTOs.UI.Checkouts;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ICheckoutRepository _checkoutRepository;
        private readonly IMapper _mapper;
        private readonly IBasketItemService _basketItemService;

        public CheckoutService(ICheckoutRepository checkoutRepository,
                               IMapper mapper,
                               IBasketItemService basketItemService)
        {
            _checkoutRepository = checkoutRepository;
            _mapper = mapper;
            _basketItemService = basketItemService;
        }

        public async Task CreateAsync(CheckoutCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);
            await _checkoutRepository.CreateAsync(_mapper.Map<Checkout>(model));
        }

        public async Task CreateByUserIdAsync(string userId)
        {
            ArgumentNullException.ThrowIfNull(userId);

            var basketItems = (List<BasketItemDto>)await _basketItemService.GetAllByUserIdAsync(userId);

            Checkout checkout = new()
            {
                UserId = userId,
                TotalPrice = basketItems.Sum(bi => bi.Price)
            };

            checkout.CheckoutMenus = basketItems.Select(bi => new CheckoutMenu
            {
                CheckoutId = checkout.Id,
                MenuId = bi.MenuId
            }).ToList();

            await _checkoutRepository.CreateAsync(checkout);

            foreach (var basketItem in basketItems)
            {
                await _basketItemService.DeleteAsync(userId, basketItem.MenuId);
            }
        }

        public async Task<IEnumerable<CheckoutDto>> GetAllByUserIdAsync(string userId)
        {
            ArgumentNullException.ThrowIfNull(userId);
            return _mapper.Map<IEnumerable<CheckoutDto>>(await _checkoutRepository.GetAllByUserIdAsync(userId));
        }
    }
}

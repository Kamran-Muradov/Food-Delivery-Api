using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.UI.Checkouts;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ICheckoutRepository _checkoutRepository;
        private readonly IMapper _mapper;
        private readonly IBasketItemRepository _basketItemRepository;

        public CheckoutService(ICheckoutRepository checkoutRepository,
                               IMapper mapper,
                               IBasketItemRepository basketItemRepository)
        {
            _checkoutRepository = checkoutRepository;
            _mapper = mapper;
            _basketItemRepository = basketItemRepository;
        }

        public async Task CreateAsync(CheckoutCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            await _checkoutRepository.CreateAsync(_mapper.Map<Checkout>(model));
        }

        public async Task CreateRangeByUserIdAsync(string userId)
        {
            var basketItems = (List<BasketItem>)await _basketItemRepository.GetAllByUserIdAsync(userId);
            await _basketItemRepository.DeleteRangeAsync(basketItems);
        }

        public async Task<IEnumerable<CheckoutDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CheckoutDto>>(await _checkoutRepository.GetAllWithMenusAsync());
        }
    }
}

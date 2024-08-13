using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.UI.BasketItems;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class BasketItemService : IBasketItemService
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IMapper _mapper;
        private readonly IBasketVariantRepository _basketVariantRepository;
        private readonly IMenuRepository _menuRepository;

        public BasketItemService(IMapper mapper,
                                 IBasketItemRepository basketItemRepository,
                                 IBasketVariantRepository basketVariantRepository, 
                                 IMenuRepository menuRepository)
        {
            _mapper = mapper;
            _basketItemRepository = basketItemRepository;
            _basketVariantRepository = basketVariantRepository;
            _menuRepository = menuRepository;
        }

        public async Task CreateAsync(BasketItemCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var existBasketItem = await _basketItemRepository.GetByUserIdAndMenuId(model.UserId, model.MenuId);

            if (existBasketItem == null)
            {
                var basketItem = _mapper.Map<BasketItem>(model);

                if (model.BasketVariants is not null)
                {
                    basketItem.BasketVariants = model.BasketVariants
                        .SelectMany(menuVariant => menuVariant.Value
                            .Select(option => new BasketVariant { Type = menuVariant.Key, Option = option })).ToList();
                }

                await _basketItemRepository.CreateAsync(basketItem);
            }
            else
            {
                await _basketVariantRepository.DeleteRangeAsync(existBasketItem.BasketVariants);
                _mapper.Map(model, existBasketItem);

                if (model.BasketVariants is not null)
                {
                    existBasketItem.BasketVariants = model.BasketVariants
                        .SelectMany(menuVariant => menuVariant.Value
                            .Select(option => new BasketVariant { Type = menuVariant.Key, Option = option })).ToList();
                }

                await _basketItemRepository.EditAsync(existBasketItem);
            }
        }

        public async Task ChangeCountAsync(BasketCountDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var basketItem = await _basketItemRepository.GetByUserIdAndMenuId(model.UserId, model.MenuId) ?? throw new NotFoundException(ResponseMessages.NotFound);

            var singlePrice = basketItem.Price / basketItem.Count;

            basketItem.Count = model.Count;
            basketItem.Price = singlePrice * model.Count;

            basketItem.UpdatedDate = DateTime.Now;
            await _basketItemRepository.EditAsync(basketItem);
        }

        public async Task DeleteAsync(string userId, int? menuId)
        {
            ArgumentNullException.ThrowIfNull(userId);
            ArgumentNullException.ThrowIfNull(menuId);

            var basketItem = await _basketItemRepository.GetByUserIdAndMenuId(userId, (int)menuId) ?? throw new NotFoundException(ResponseMessages.NotFound);

            await _basketItemRepository.DeleteAsync(basketItem);
        }

        public async Task<IEnumerable<BasketItemDto>> GetAllByUserIdAsync(string userId)
        {
            return _mapper.Map<IEnumerable<BasketItemDto>>(await _basketItemRepository.GetAllByUserIdAsync(userId));
        }

        public async Task<bool> IsDifferentRestaurantAsync(string userId, int menuId)
        {
            var basketItems = await _basketItemRepository.GetAllByUserIdAsync(userId);

            var menu = await _menuRepository.GetByIdAsync(menuId);

            return basketItems.Any() && basketItems.First().Menu.RestaurantId != menu.RestaurantId;
        }

        public async Task ResetAsync(BasketItemCreateDto model)
        {
            var existBasketItems = await _basketItemRepository.GetAllByUserIdAsync(model.UserId);
            await _basketItemRepository.DeleteRangeAsync(existBasketItems.ToList());

            var basketItem = _mapper.Map<BasketItem>(model);

            if (model.BasketVariants is not null)
            {
                basketItem.BasketVariants = model.BasketVariants
                    .SelectMany(menuVariant => menuVariant.Value
                        .Select(option => new BasketVariant { Type = menuVariant.Key, Option = option })).ToList();
            }

            await _basketItemRepository.CreateAsync(basketItem);
        }
    }
}

using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Checkouts;
using Service.DTOs.UI.BasketItems;
using Service.DTOs.UI.Checkouts;
using Service.Helpers;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Helpers.SignalR;
using Service.Services.Interfaces;
using CheckoutDto = Service.DTOs.UI.Checkouts.CheckoutDto;

namespace Service.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ICheckoutRepository _checkoutRepository;
        private readonly IMapper _mapper;
        private readonly IBasketItemService _basketItemService;
        private readonly IMenuRepository _menuRepository;
        private readonly IHubContext<CheckoutHub> _hubContext;

        public CheckoutService(ICheckoutRepository checkoutRepository,
                               IMapper mapper,
                               IBasketItemService basketItemService, 
                               IMenuRepository menuRepository, 
                               IHubContext<CheckoutHub> hubContext)
        {
            _checkoutRepository = checkoutRepository;
            _mapper = mapper;
            _basketItemService = basketItemService;
            _menuRepository = menuRepository;
            _hubContext = hubContext;
        }

        public async Task CreateAsync(CheckoutCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            Checkout checkout = _mapper.Map<Checkout>(model);

            var basketItems = (List<BasketItemDto>)await _basketItemService.GetAllByUserIdAsync(model.UserId);
            var menu = await _menuRepository.GetByIdAsync(basketItems.First().MenuId);

            checkout.RestaurantId = menu.RestaurantId;
            checkout.TotalPrice = basketItems.Sum(bi => bi.Price);
            checkout.CheckoutMenus = basketItems.Select(bi => new CheckoutMenu
            {
                CheckoutId = checkout.Id,
                MenuId = bi.MenuId
            }).ToList();

            await _checkoutRepository.CreateAsync(checkout);

            foreach (var basketItem in basketItems)
            {
                await _basketItemService.DeleteAsync(model.UserId, basketItem.MenuId);
            }
        }

        public async Task EditAsync(int? id, CheckoutEditDto model)
        {
           ArgumentNullException.ThrowIfNull(id);
           ArgumentNullException.ThrowIfNull(model);

           var checkout = await _checkoutRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);
           checkout.Status = model.Status;
           await _checkoutRepository.EditAsync(checkout);

           
           if (model.Status == "Delivered")
           {
               await _hubContext.Clients.Group(checkout.UserId).SendAsync("ReceiveOrderStatusUpdate", id, model.Status);
           }
        }

        public async Task CreateByUserIdAsync(string userId)
        {
            ArgumentNullException.ThrowIfNull(userId);

            var basketItems = (List<BasketItemDto>)await _basketItemService.GetAllByUserIdAsync(userId);

            var menu = await _menuRepository.GetByIdAsync(basketItems.First().MenuId);

            Checkout checkout = new()
            {
                UserId = userId,
                TotalPrice = basketItems.Sum(bi => bi.Price),
                RestaurantId = menu.RestaurantId
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

        public async Task<PaginationResponse<DTOs.Admin.Checkouts.CheckoutDto>> GetPaginateAsync(int? page, int? take)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            var checkouts = await _checkoutRepository.GetAllAsync();
            int totalPage = (int)Math.Ceiling((decimal)checkouts.Count() / (int)take);

            var mappedDatas = _mapper.Map<IEnumerable<DTOs.Admin.Checkouts.CheckoutDto>>(await _checkoutRepository.GetPaginateDatasAsync((int)page, (int)take));

            return new PaginationResponse<DTOs.Admin.Checkouts.CheckoutDto>(mappedDatas, totalPage, (int)page);        }
    }
}

using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Checkouts;
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
        private readonly IHubContext<CheckoutHub> _hubContext;
        private readonly IUserPromoCodeRepository _userPromoCodeRepository;
        private readonly IBasketItemRepository _basketItemRepository;

        public CheckoutService(ICheckoutRepository checkoutRepository,
                               IMapper mapper,
                               IHubContext<CheckoutHub> hubContext, 
                               IUserPromoCodeRepository userPromoCodeRepository, 
                               IBasketItemRepository basketItemRepository)
        {
            _checkoutRepository = checkoutRepository;
            _mapper = mapper;
            _hubContext = hubContext;
            _userPromoCodeRepository = userPromoCodeRepository;
            _basketItemRepository = basketItemRepository;
        }

        public async Task CreateAsync(CheckoutCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            Checkout checkout = _mapper.Map<Checkout>(model);

            var basketItems = (List<BasketItem>)await _basketItemRepository.GetAllByUserIdAsync(model.UserId);

            decimal totalPrice;
            if (basketItems.First().DiscountPrice != null)
            {
                totalPrice = (decimal)basketItems.Sum(bi => bi.DiscountPrice) + basketItems.First().Menu.Restaurant.DeliveryFee;
            }
            else
            {
                totalPrice = basketItems.Sum(bi => bi.Price) + basketItems.First().Menu.Restaurant.DeliveryFee;
            }

            checkout.RestaurantId = basketItems.First().Menu.RestaurantId;
            checkout.TotalPrice = totalPrice;
            checkout.CheckoutMenus = basketItems.Select(bi => new CheckoutMenu
            {
                CheckoutId = checkout.Id,
                MenuId = bi.MenuId
            }).ToList();
            if (string.IsNullOrWhiteSpace(model.Comments))
            {
                checkout.Comments = null;
            }

            await _checkoutRepository.CreateAsync(checkout);

            var deletedBasketItems = await _basketItemRepository.GetAllWithExpressionAsync(bi => bi.UserId == model.UserId);

           
                await _basketItemRepository.DeleteRangeAsync(deletedBasketItems.ToList());

            var activeUserPromoCode = await _userPromoCodeRepository.GetActiveByUserIdAsync(model.UserId);
            if (activeUserPromoCode != null)
            {
                activeUserPromoCode.IsUsed = true;
                await _userPromoCodeRepository.EditAsync(activeUserPromoCode);
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

        public async Task<IEnumerable<CheckoutDto>> GetAllByUserIdAsync(string userId)
        {
            ArgumentNullException.ThrowIfNull(userId);
            return _mapper.Map<IEnumerable<CheckoutDto>>(await _checkoutRepository.GetAllByUserIdAsync(userId));
        }

        public async Task<CheckoutDetailDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return _mapper.Map<CheckoutDetailDto>(await _checkoutRepository.GetByIdWithAllDatasAsync((int)id));
        }

        public async Task<PaginationResponse<DTOs.Admin.Checkouts.CheckoutDto>> GetPaginateAsync(int? page, int? take)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            var checkouts = await _checkoutRepository.GetAllAsync();
            int totalPage = (int)Math.Ceiling((decimal)checkouts.Count() / (int)take);

            var mappedDatas = _mapper.Map<IEnumerable<DTOs.Admin.Checkouts.CheckoutDto>>(await _checkoutRepository.GetPaginateDatasAsync((int)page, (int)take));

            return new PaginationResponse<DTOs.Admin.Checkouts.CheckoutDto>(mappedDatas, totalPage, (int)page);
        }
    }
}

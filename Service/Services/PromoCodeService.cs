using System.Linq.Expressions;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.PromoCodes;
using Service.DTOs.UI.PromoCodes;
using Service.Helpers;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using PromoCodeDto = Service.DTOs.Admin.PromoCodes.PromoCodeDto;

namespace Service.Services
{
    public class PromoCodeService : IPromoCodeService
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IUserPromoCodeRepository _userPromoCodeRepository;
        private readonly IPromoCodeRepository _promoCodeRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public PromoCodeService(IBasketItemRepository basketItemRepository,
                                IUserPromoCodeRepository userPromoCodeRepository,
                                IPromoCodeRepository promoCodeRepository,
                                UserManager<AppUser> userManager,
                                IMapper mapper)
        {
            _basketItemRepository = basketItemRepository;
            _userPromoCodeRepository = userPromoCodeRepository;
            _promoCodeRepository = promoCodeRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task CreateAsync(PromoCodeCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var promoCode = _mapper.Map<PromoCode>(model);
            promoCode.Code = Guid.NewGuid().ToString().Substring(0, 5).ToUpper();
            await _promoCodeRepository.CreateAsync(promoCode);
        }

        public async Task EditAsync(int? id, PromoCodeEditDto model)
        {
            ArgumentNullException.ThrowIfNull(model);
            ArgumentNullException.ThrowIfNull(id);

            var promoCode = await _promoCodeRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);
            await _promoCodeRepository.EditAsync(_mapper.Map(model, promoCode));
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var promoCode = await _promoCodeRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);
            await _promoCodeRepository.DeleteAsync(promoCode);
        }

        public async Task<PaginationResponse<PromoCodeDto>> GetPaginateAsync(int? page, int? take)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            var promoCodes = await _promoCodeRepository.GetAllAsync();
            int totalPage = (int)Math.Ceiling((decimal)promoCodes.Count() / (int)take);

            var mappedDatas = _mapper.Map<IEnumerable<PromoCodeDto>>(await _promoCodeRepository.GetPaginateDatasAsync((int)page, (int)take));

            return new PaginationResponse<PromoCodeDto>(mappedDatas, totalPage, (int)page);
        }

        public async Task<IEnumerable<DTOs.UI.PromoCodes.PromoCodeDto>> GetAllWithExpressionAsync(Expression<Func<PromoCode, bool>> predicate)
        {
            return _mapper.Map<IEnumerable<DTOs.UI.PromoCodes.PromoCodeDto>>(await _promoCodeRepository.GetAllWithExpressionAsync(predicate));
        }

        public async Task<PromoCodeDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            return _mapper.Map<PromoCodeDto>(await _promoCodeRepository.GetByIdAsync((int)id));
        }

        public async Task<PromoCodeResponse> ApplyToBasketAsync(UserPromoCodeDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) throw new NotFoundException("User not found");

            var promoCode = await _promoCodeRepository.GetFirstWithExpressionAsync(pc => pc.Code == model.Code);

            if (promoCode == null) return new PromoCodeResponse { Success = false, Error = "Invalid promo code" };
            if (!promoCode.IsActive) return new PromoCodeResponse { Success = false, Error = "Promo code is not active" };
            if (promoCode.ExpiryDate < DateTime.Now) return new PromoCodeResponse { Success = false, Error = "Promo code expired" };

            var userPromoCodes = await _userPromoCodeRepository.GetAllWithExpressionAsync(upc => upc.UserId == model.UserId);

            if (userPromoCodes.Any(upc => upc.PromoCodeId == promoCode.Id)) return new PromoCodeResponse { Success = false, Error = "You already used this promo code" };
            if (userPromoCodes.Any(upc => !upc.IsUsed)) return new PromoCodeResponse { Success = false, Error = "You already have an active promo code" };

            var basketItems = await _basketItemRepository.GetAllWithExpressionAsync(bi => bi.UserId == model.UserId);


            foreach (var basketItem in basketItems)
            {
                basketItem.DiscountPrice = basketItem.Price - basketItem.Price * (decimal)promoCode.Discount / 100;
                await _basketItemRepository.EditAsync(basketItem);
            }

            await _userPromoCodeRepository.CreateAsync(new UserPromoCode { UserId = model.UserId, PromoCodeId = promoCode.Id, IsUsed = false });
            return new PromoCodeResponse { Success = true, Discount = promoCode.Discount };
        }

        public async Task DeleteUserPromoCodeAsync(string userId)
        {
            ArgumentNullException.ThrowIfNull(userId);

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new NotFoundException("User not found");

            var activeUserPromoCode = await _userPromoCodeRepository.GetActiveByUserIdAsync(userId);
            if (activeUserPromoCode != null)
            {
                await _userPromoCodeRepository.DeleteAsync(activeUserPromoCode);

                var basketItems = await _basketItemRepository.GetAllWithExpressionAsync(bi => bi.UserId == userId);
                foreach (var basketItem in basketItems)
                {
                    basketItem.DiscountPrice = null;
                    await _basketItemRepository.EditAsync(basketItem);
                }
            }
        }
    }
}

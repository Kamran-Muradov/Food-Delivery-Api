using Service.DTOs.Admin.PromoCodes;
using Service.DTOs.UI.PromoCodes;
using Service.Helpers;
using System.Linq.Expressions;
using Domain.Entities;
using PromoCodeDto = Service.DTOs.Admin.PromoCodes.PromoCodeDto;

namespace Service.Services.Interfaces
{
    public interface IPromoCodeService
    {
        Task CreateAsync(PromoCodeCreateDto model);
        Task EditAsync(int? id, PromoCodeEditDto model);
        Task DeleteAsync(int? id);
        Task<PaginationResponse<PromoCodeDto>> GetPaginateAsync(int? page, int? take);
        Task<IEnumerable<DTOs.UI.PromoCodes.PromoCodeDto>> GetAllWithExpressionAsync(Expression<Func<PromoCode, bool>> predicate);
        Task<PromoCodeDto> GetByIdAsync(int? id);
        Task<PromoCodeResponse> ApplyToBasketAsync(UserPromoCodeDto model);
        Task DeleteUserPromoCodeAsync(string userId);
    }
}

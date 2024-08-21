using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IPromoCodeRepository : IBaseRepository<PromoCode>
    {
        Task<IEnumerable<PromoCode>> GetPaginateDatasAsync(int page, int take);
    }
}

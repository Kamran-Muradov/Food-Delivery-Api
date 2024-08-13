using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface ICheckoutRepository : IBaseRepository<Checkout>
    {
        Task<IEnumerable<Checkout>> GetAllByUserIdAsync(string userId);
        Task<IEnumerable<Checkout>> GetPaginateDatasAsync(int page, int take);
        Task<Checkout> GetByIdWithAllDatasAsync(int id);
    }
}

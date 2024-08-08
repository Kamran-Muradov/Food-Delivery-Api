using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface ICheckoutRepository : IBaseRepository<Checkout>
    {
        Task<IEnumerable<Checkout>> GetAllByUserIdAsync(string userId);
    }
}

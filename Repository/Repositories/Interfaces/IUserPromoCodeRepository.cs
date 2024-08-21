using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IUserPromoCodeRepository : IBaseRepository<UserPromoCode>
    {
        Task<UserPromoCode> GetActiveByUserIdAsync(string userId);
    }
}

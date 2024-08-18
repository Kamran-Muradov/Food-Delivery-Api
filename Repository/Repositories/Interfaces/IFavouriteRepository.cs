using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IFavouriteRepository : IBaseRepository<Favourite>
    {
        Task<IEnumerable<Favourite>> GetAllByUserIdAsync(string userId);
    }
}

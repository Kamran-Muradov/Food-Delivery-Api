using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IRestaurantTagRepository : IBaseRepository<RestaurantTag>
    {
        Task<RestaurantTag> GetByIdAsync(int restaurantId, int categoryId);
    }
}

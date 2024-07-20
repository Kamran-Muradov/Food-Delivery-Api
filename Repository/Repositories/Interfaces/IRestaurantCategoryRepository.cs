using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IRestaurantCategoryRepository : IBaseRepository<RestaurantCategory>
    {
        Task<RestaurantCategory> GetByIdAsync(int restaurantId, int categoryId);
    }
}

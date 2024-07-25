using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IRestaurantImageRepository : IBaseRepository<RestaurantImage>
    {
        Task<IEnumerable<RestaurantImage>> GetAllByRestaurantIdAsync(int  restaurantId);
    }
}

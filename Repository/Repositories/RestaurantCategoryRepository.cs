using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class RestaurantCategoryRepository : BaseRepository<RestaurantCategory>, IRestaurantCategoryRepository
    {
        public RestaurantCategoryRepository(AppDbContext context) : base(context) { }
        public async Task<RestaurantCategory> GetByIdAsync(int restaurantId, int categoryId)
        {
            return await _entities
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CategoryId == categoryId && m.RestaurantId == restaurantId);
        }
    }
}

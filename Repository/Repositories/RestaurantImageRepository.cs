using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class RestaurantImageRepository : BaseRepository<RestaurantImage>, IRestaurantImageRepository
    {
        public RestaurantImageRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<RestaurantImage>> GetAllByRestaurantIdAsync(int restaurantId)
        {
            return await _entities
                .Where(m => m.RestaurantId == restaurantId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

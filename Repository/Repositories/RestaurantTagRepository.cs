using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class RestaurantTagRepository : BaseRepository<RestaurantTag>, IRestaurantTagRepository
    {
        public RestaurantTagRepository(AppDbContext context) : base(context) { }
        public async Task<RestaurantTag> GetByIdAsync(int restaurantId, int categoryId)
        {
            return await Entities
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TagId == categoryId && m.RestaurantId == restaurantId);
        }
    }
}

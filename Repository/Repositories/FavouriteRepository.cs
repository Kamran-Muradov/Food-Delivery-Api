using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class FavouriteRepository : BaseRepository<Favourite>, IFavouriteRepository
    {
        public FavouriteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Favourite>> GetAllByUserIdAsync(string userId)
        {
            return await Entities
                .Where(f => f.UserId == userId)
                .Include(f => f.Restaurant)
                .ThenInclude(r=>r.RestaurantImages)
                .ToListAsync();
        }
    }
}

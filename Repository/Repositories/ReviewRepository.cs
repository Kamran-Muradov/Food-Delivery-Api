using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Review>> GetALlWithUsersAsync()
        {
            return await Entities
                .OrderByDescending(r => r.Id)
                .Where(r => r.Comment != null)
                .Include(r => r.Checkout)
                .ThenInclude(c => c.User)
                .ThenInclude(c => c.UserImage)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetALlByRestaurantIdAsync(int restaurantId)
        {
            return await Entities
                .OrderByDescending(r => r.Id)
                .Where(r => r.Checkout.RestaurantId == restaurantId)
                .Include(r => r.Checkout)
                .ThenInclude(c => c.User)
                .ThenInclude(c => c.UserImage)
                .ToListAsync();
        }
    }
}

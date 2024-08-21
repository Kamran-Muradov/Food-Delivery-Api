using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class UserPromoCodeRepository : BaseRepository<UserPromoCode>, IUserPromoCodeRepository
    {
        public UserPromoCodeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<UserPromoCode> GetActiveByUserIdAsync(string userId)
        {
            return await Entities
                .Where(upc => upc.UserId == userId && !upc.IsUsed)
                .Include(upc => upc.PromoCode)
                .FirstOrDefaultAsync();
        }
    }
}

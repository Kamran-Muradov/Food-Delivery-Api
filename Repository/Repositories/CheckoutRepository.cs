using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class CheckoutRepository : BaseRepository<Checkout>, ICheckoutRepository
    {
        public CheckoutRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Checkout>> GetAllByUserIdAsync(string userId)
        {
            return await Entities
                .Where(c => c.UserId == userId)
                .Include(c => c.Review)
                .Include(c => c.Restaurant)
                .OrderByDescending(c => c.Id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Checkout>> GetPaginateDatasAsync(int page, int take)
        {
            return await Entities
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .Include(m => m.User)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Checkout> GetByIdWithAllDatasAsync(int id)
        {
            return await Entities
                .Where(c => c.Id == id)
                .Include(c => c.Restaurant)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}

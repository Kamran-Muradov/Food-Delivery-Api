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

        public async Task<IEnumerable<Checkout>> GetAllWithMenusAsync()
        {
            return await Entities
                .Include(c => c.Menu)
                .Include(c => c.User)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

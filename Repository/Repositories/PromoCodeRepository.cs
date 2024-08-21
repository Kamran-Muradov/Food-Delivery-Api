using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class PromoCodeRepository : BaseRepository<PromoCode>, IPromoCodeRepository
    {
        public PromoCodeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PromoCode>> GetPaginateDatasAsync(int page, int take)
        {
            return await Entities
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

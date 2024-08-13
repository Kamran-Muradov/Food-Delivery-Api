using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class BrandLogoRepository : BaseRepository<BrandLogo>, IBrandLogoRepository
    {
        public BrandLogoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<BrandLogo> GetByBrandIdAsync(int brandId)
        {
            return await Entities
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.BrandId == brandId);
        }
    }
}

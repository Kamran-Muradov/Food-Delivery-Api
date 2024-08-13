using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Brand>> GetPaginateDatasAsync(int page, int take)
        {
            return await Entities
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .Include(m => m.BrandLogo)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Brand>> GetAllWithLogoAsync()
        {
            return await Entities
                .Include(m => m.BrandLogo)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Brand> GetByIdWithLogoAsync(int id)
        {
            return await Entities
                .Where(m => m.Id == id)
                .Include(m => m.BrandLogo)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<bool> ExistAsync(string name, int? excludeId = null)
        {
            return await Entities
                .Where(m => m.Id != excludeId)
                .AnyAsync(m => m.Name == name);
        }
    }
}

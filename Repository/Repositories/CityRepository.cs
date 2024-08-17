using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<City>> GetPaginateDatasAsync(int page, int take)
        {
            return await Entities
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .Include(c => c.Country)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<City> GetByIdWithCountryAsync(int id)
        {
            return await Entities
                .Where(c => c.Id == id)
                .Include(c => c.Country)
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

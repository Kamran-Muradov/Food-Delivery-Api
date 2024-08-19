using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class VariantTypeRepository : BaseRepository<VariantType>, IVariantTypeRepository
    {
        public VariantTypeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<VariantType>> GetPaginateDatasAsync(int page, int take)
        {
            return await Entities
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> ExistAsync(string name, int? excludeId = null)
        {
            return await Entities
                .Where(m => m.Id != excludeId)
                .AnyAsync(m => m.Name == name);
        }
    }
}

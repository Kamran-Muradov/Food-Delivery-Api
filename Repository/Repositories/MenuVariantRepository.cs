using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class MenuVariantRepository : BaseRepository<MenuVariant>, IMenuVariantRepository
    {
        public MenuVariantRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MenuVariant>> GetPaginateDatasAsync(int page, int take)
        {
            return await _entities
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<MenuVariant> GetByIdWithAllDatasAsync(int id)
        {
            return await _entities
                .Where(m => m.Id == id)
                .Include(m => m.Menu)
                .Include(m => m.VariantType)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> ExistAsync(int menuId, int variantTypeId, string option, int? excludeId = null)
        {
            return await _entities
                .Where(m => m.Id != excludeId)
                .AnyAsync(m => m.Option == option && m.MenuId == menuId && m.VariantTypeId == variantTypeId);
        }
    }
}

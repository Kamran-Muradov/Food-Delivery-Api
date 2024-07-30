using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Menu>> GetPaginateDatasAsync(int page, int take)
        {
            return await _entities
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .Include(m => m.MenuImage)
                .Include(m => m.Restaurant)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Menu> GetByIdWithAllDatasAsync(int id)
        {
            return await _entities
                .Where(m => m.Id == id)
                .Include(m => m.MenuIngredients)
                .ThenInclude(m => m.Ingredient)
                .Include(m => m.MenuCategories)
                .ThenInclude(m => m.Category)
                .Include(m => m.MenuImage)
                .Include(m => m.Restaurant)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Menu> GetByIdWithImageAsync(int id)
        {
            return await _entities
                .Where(m => m.Id == id)
                .Include(m => m.MenuImage)
                .Include(m => m.MenuCategories)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Menu>> SearchByNameAndCategory(string searchText)
        {
            return await _entities
                .Where(m => m.Name.Contains(searchText) || m.MenuCategories.Any(mc => mc.Category.Name.Contains(searchText)))
                .Include(m => m.MenuImage)
                .Include(m => m.MenuCategories)
                .ThenInclude(mc => mc.Category)
                .Include(m => m.MenuIngredients)
                .ThenInclude(mi => mi.Ingredient)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

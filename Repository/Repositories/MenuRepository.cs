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
            return await Entities
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
            return await Entities
                .Where(m => m.Id == id)
                .Include(m => m.MenuIngredients)
                .ThenInclude(m => m.Ingredient)
                .Include(m => m.Category)
                .Include(m => m.MenuImage)
                .Include(m => m.Restaurant)
                .Include(m => m.MenuVariants)
                .ThenInclude(mv => mv.VariantType)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Menu> GetByIdWithImageAsync(int id)
        {
            return await Entities
                .Where(m => m.Id == id)
                .Include(m => m.MenuImage)
                .Include(m => m.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Menu>> SearchByNameAndCategory(string searchText)
        {
            return await Entities
                .Where(m => m.Name.Contains(searchText) || m.Category.Name.Contains(searchText))
                .Include(m => m.MenuImage)
                .Include(m => m.Category)
                .Include(m => m.MenuIngredients)
                .ThenInclude(mi => mi.Ingredient)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

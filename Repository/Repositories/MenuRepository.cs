using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Menu>> GetPaginateDatasAsync(int page, int take, string? searchText)
        {
            var query = Entities.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query = query.Where(m => m.Name.Contains(searchText));
            }

            query = query
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .Include(m => m.MenuImage)
                .Include(m => m.Restaurant)
                .AsNoTracking();

            return await query.ToListAsync();
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

        public async Task<IEnumerable<Menu>> SearchByRestaurantId(int restaurantId, string? searchText)
        {
            var query = Entities
                .AsQueryable()
                .Where(m => m.RestaurantId == restaurantId);

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query = query.Where(m => m.Name.Contains(searchText) || m.Category.Name.Contains(searchText));
            }

            return await query
                .Include(m => m.MenuImage)
                .Include(m => m.Category)
                .Include(m => m.MenuIngredients)
                .ThenInclude(mi => mi.Ingredient)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

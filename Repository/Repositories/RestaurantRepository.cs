using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class RestaurantRepository : BaseRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Restaurant>> GetPaginateDatasAsync(int page, int take)
        {
            return await _entities
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .Include(m => m.RestaurantImages)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllWithImagesAsync()
        {
            return await _entities
                .Include(m => m.RestaurantImages)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Restaurant> GetByIdWithAllDatasAsync(int id)
        {
            return await _entities
                .Where(m => m.Id == id)
                .Include(m => m.RestaurantCategories)
                .ThenInclude(m => m.Category)
                .Include(m => m.RestaurantImages)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Restaurant> GetByIdWithImagesAsync(int id)
        {
            return await _entities
                .Where(m => m.Id == id)
                .Include(m => m.RestaurantImages)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Restaurant> GetByIdWithMenusAsync(int id)
        {
            return await _entities
                .Where(m => m.Id == id)
                .Include(m => m.Menus)
                .ThenInclude(m => m.MenuCategories)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Restaurant>> SearchByNameAndCategory(string searchText)
        {
            return await _entities
                .Where(m => m.Name.Contains(searchText) || m.RestaurantCategories.Any(mc => mc.Category.Name.Contains(searchText)))
                .OrderByDescending(m => m.Rating)
                .Include(m => m.RestaurantImages)
                .Include(m => m.RestaurantCategories)
                .ThenInclude(m => m.Category)
                .Include(m => m.RestaurantImages)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

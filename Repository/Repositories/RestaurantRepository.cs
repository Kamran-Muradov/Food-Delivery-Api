using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
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

        public async Task<IEnumerable<Restaurant>> GetLoadMoreAsync(int page, int take, string sorting, List<int>? categoryIds)
        {
            var query = _entities.AsQueryable();

            if (categoryIds is not null && categoryIds.Any())
            {
                query = query.Where(m => m.RestaurantCategories.Any(rc => categoryIds.Contains(rc.CategoryId)));
            }

            query = sorting switch
            {
                "recent" => query.OrderByDescending(m => m.Id),
                "deliveryTime" => query.OrderBy(m => m.MinDeliveryTime),
                "deliveryFee" => query.OrderBy(m => m.DeliveryFee),
                "rating" => query.OrderByDescending(m => m.Rating),
                _ => query
            };

            return await query
                 .Skip((page - 1) * take)
                 .Take(take)
                 .Include(m => m.RestaurantImages)
                 .Include(m => m.RestaurantCategories)
                 .ThenInclude(m => m.Category)
                 .AsNoTracking()
                 .ToListAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllWithImagesAsync()
        {
            return await _entities
                .Include(m => m.RestaurantImages)
                .Include(m => m.RestaurantCategories)
                .ThenInclude(m => m.Category)
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
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

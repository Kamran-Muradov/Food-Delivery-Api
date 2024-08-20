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
            return await Entities
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .Include(m => m.RestaurantImages)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllFilteredAsync(int page, int take, string sorting, List<int>? categoryIds)
        {
            var query = Entities.AsQueryable();

            if (categoryIds is not null && categoryIds.Any())
            {
                query = query.Where(m => m.RestaurantTags.Any(rc => categoryIds.Contains(rc.TagId)));
            }

            query = sorting switch
            {
                "recent" => query.OrderByDescending(m => m.Id),
                "deliveryTime" => query.OrderBy(m => m.MinDeliveryTime),
                "deliveryFee" => query.OrderBy(m => m.DeliveryFee),
                "rating" => query.OrderByDescending(m => m.AverageRating),
                _ => query
            };

            return await query
                 .Skip((page - 1) * take)
                 .Take(take)
                 .Include(m => m.RestaurantImages)
                 .Include(m => m.RestaurantTags)
                 .ThenInclude(m => m.Tag)
                 .AsNoTracking()
                 .ToListAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllByBrandIdAsync(int brandId)
        {
            return await Entities
                .Where(r => r.Brand.Id == brandId)
                .Include(m => m.RestaurantImages)
                .Include(m => m.RestaurantTags)
                .ThenInclude(m => m.Tag)
                .Include(r => r.Brand)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllByTagIdAsync(int tagId)
        {
            return await Entities
                .Where(r => r.RestaurantTags.Any(rt => rt.TagId == tagId))
                .Include(m => m.RestaurantImages)
                .Include(m => m.RestaurantTags)
                .ThenInclude(m => m.Tag)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllWithImagesAsync()
        {
            return await Entities
                .Include(m => m.RestaurantImages)
                .Include(m => m.RestaurantTags)
                .ThenInclude(m => m.Tag)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Restaurant?> GetByIdWithAllDatasAsync(int id)
        {
            return await Entities
                .Where(r => r.Id == id)
                .Include(r => r.RestaurantTags)
                .ThenInclude(rc => rc.Tag)
                .Include(r => r.RestaurantImages)
                .Include(r => r.Menus)
                .ThenInclude(m => m.MenuImage)
                .Include(r => r.Menus)
                .ThenInclude(m => m.MenuIngredients)
                .ThenInclude(mi => mi.Ingredient)
                .Include(r => r.Menus)
                .ThenInclude(m => m.Category)
                .Include(r => r.Brand)
                .Include(r => r.City)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Restaurant> GetByIdWithImagesAsync(int id)
        {
            return await Entities
                .Where(m => m.Id == id)
                .Include(m => m.RestaurantImages)
                .Include(m => m.RestaurantTags)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Restaurant>> SearchByNameAndCategory(string searchText)
        {
            return await Entities
                .Where(m => m.Name.Contains(searchText) || m.RestaurantTags.Any(mc => mc.Tag.Name.Contains(searchText)))
                .OrderByDescending(m => m.AverageRating)
                .Include(m => m.RestaurantImages)
                .Include(m => m.RestaurantTags)
                .ThenInclude(m => m.Tag)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

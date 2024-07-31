using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Category>> GetPaginateDatasAsync(int page, int take)
        {
            return await _entities
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .Include(m => m.CategoryImage)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllWithImageAsync()
        {
            return await _entities
                .Include(m => m.CategoryImage)
                .Include(m => m.RestaurantCategories)
                .Include(m => m.MenuCategories)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category> GetByIdWithImageAsync(int id)
        {
            return await _entities
                .Where(m => m.Id == id)
                .Include(m => m.CategoryImage)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Category> GetByNameAsync(string name)
        {
            return await _entities.AsNoTracking().FirstOrDefaultAsync(m => m.Name == name);
        }

        public async Task<bool> ExistAsync(string name, int? excludeId = null)
        {
            return await _entities
                .Where(m => m.Id != excludeId)
                .AnyAsync(m => m.Name == name);
        }
    }
}

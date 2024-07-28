using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class CategoryImageRepository : BaseRepository<CategoryImage>, ICategoryImageRepository
    {
        public CategoryImageRepository(AppDbContext context) : base(context) { }
        public async Task<CategoryImage> GetByCategoryIdAsync(int categoryId)
        {
            return await _entities
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CategoryId == categoryId);
        }
    }
}

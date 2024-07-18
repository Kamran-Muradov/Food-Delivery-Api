using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<Category> GetByNameAsync(string name)
        {
            return await _entities.AsNoTracking().FirstOrDefaultAsync(m => m.Name == name);
        }
    }
}

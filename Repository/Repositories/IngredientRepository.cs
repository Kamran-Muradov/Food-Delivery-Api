using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(AppDbContext context) : base(context) { }

        public async Task<Ingredient> GetByNameAsync(string name)
        {
            return await _entities.AsNoTracking().FirstOrDefaultAsync(m => m.Name == name);
        }

        public async Task<IEnumerable<Ingredient>> GetPaginateDatasAsync(int page, int take)
        {
            return await _entities
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> ExistAsync(string name, int? excludeId = null)
        {
            return await _entities
                .Where(m => m.Id != excludeId)
                .AnyAsync(m => m.Name == name);
        }
    }
}

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
    }
}

using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class MenuIngredientRepository : BaseRepository<MenuIngredient>, IMenuIngredientRepository
    {
        public MenuIngredientRepository(AppDbContext context) : base(context)
        {
        }
    }
}

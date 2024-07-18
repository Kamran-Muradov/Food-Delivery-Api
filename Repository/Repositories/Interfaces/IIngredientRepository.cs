using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IIngredientRepository : IBaseRepository<Ingredient>
    {
        Task<Ingredient> GetByNameAsync(string name);
    }
}

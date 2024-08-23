using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IIngredientRepository : IBaseRepository<Ingredient>
    {
        Task<Ingredient> GetByNameAsync(string name);
        Task<IEnumerable<Ingredient>> GetPaginateDatasAsync(int page, int take, string? searchText);
        Task<bool> ExistAsync(string name, int? excludeId = null);
    }
}

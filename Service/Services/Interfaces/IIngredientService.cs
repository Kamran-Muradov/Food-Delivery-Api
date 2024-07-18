using Service.DTOs.Admin.Ingredients;

namespace Service.Services.Interfaces
{
    public interface IIngredientService
    {
        Task CreateAsync(IngredientCreateDto model);
        Task EditAsync(int? id, IngredientEditDto model);
        Task DeleteAsync(int? id);
        Task<IEnumerable<IngredientDto>> GetAllAsync();
        Task<IngredientDto> GetByIdAsync(int? id);
    }
}

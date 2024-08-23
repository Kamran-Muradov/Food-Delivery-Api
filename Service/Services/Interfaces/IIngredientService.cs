using Service.DTOs.Admin.Ingredients;
using Service.Helpers;

namespace Service.Services.Interfaces
{
    public interface IIngredientService
    {
        Task CreateAsync(IngredientCreateDto model);
        Task EditAsync(int? id, IngredientEditDto model);
        Task DeleteAsync(int? id);
        Task<IEnumerable<IngredientDto>> GetAllAsync();
        Task<IEnumerable<IngredientSelectDto>> GetAllForSelectAsync(int? excludeId = null);
        Task<PaginationResponse<IngredientDto>> GetPaginateAsync(int? page, int? take, string? searchText);
        Task<IngredientDto> GetByIdAsync(int? id);
        Task<bool> ExistAsync(string name, int? excludeId = null);
    }
}

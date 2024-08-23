using Service.DTOs.Admin.Categories;
using Service.Helpers;
using CategoryDto = Service.DTOs.UI.Categories.CategoryDto;

namespace Service.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryCreateDto model);
        Task EditAsync(int? id, CategoryEditDto model);
        Task DeleteAsync(int? id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<IEnumerable<CategorySelectDto>> GetAllForSelectAsync(int? excludeId = null);
        Task<PaginationResponse<DTOs.Admin.Categories.CategoryDto>> GetPaginateAsync(int? page, int? take,
            string? searchText);
        Task<CategoryDto> GetByIdAsync(int? id);
        Task<bool> ExistAsync(string name, int? excludeId = null);
    }
}

using Service.DTOs.Admin.Categories;

namespace Service.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryCreateDto model);
        Task EditAsync(int? id, CategoryEditDto model);
        Task DeleteAsync(int? id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int? id);
    }
}

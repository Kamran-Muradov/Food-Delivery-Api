using Service.DTOs.Admin.Categories;

namespace Service.Services.Interfaces
{
    public interface ICategoryImageService
    {
        Task<CategoryImageDto> GetByCategoryIdAsync(int? categoryId);
    }
}

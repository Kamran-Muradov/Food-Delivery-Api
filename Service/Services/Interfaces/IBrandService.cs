using Service.DTOs.Admin.Brands;
using Service.Helpers;

namespace Service.Services.Interfaces
{
    public interface IBrandService
    {
        Task CreateAsync(BrandCreateDto model);
        Task EditAsync(int? id, BrandEditDto model);
        Task DeleteAsync(int? id);
        Task<IEnumerable<DTOs.UI.Brands.BrandDto>> GetAllAsync();
        Task<IEnumerable<BrandSelectDto>> GetAllForSelectAsync(int? excludeId = null);
        Task<PaginationResponse<BrandDto>> GetPaginateAsync(int? page, int? take);
        Task<BrandDto> GetByIdAsync(int? id);
        Task<bool> ExistAsync(string name, int? excludeId = null);
    }
}

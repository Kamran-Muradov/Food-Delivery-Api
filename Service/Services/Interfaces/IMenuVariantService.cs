using Service.DTOs.Admin.Ingredients;
using Service.DTOs.Admin.MenuVariants;
using Service.Helpers;

namespace Service.Services.Interfaces
{
    public interface IMenuVariantService
    {
        Task CreateAsync(MenuVariantCreateDto model);
        Task EditAsync(int? id, MenuVariantEditDto model);
        Task DeleteAsync(int? id);
        Task<PaginationResponse<MenuVariantDto>> GetPaginateAsync(int? page, int? take);
        Task<MenuVariantDetailDto> GetByIdAsync(int? id);

        Task<bool> ExistAsync(int? menuId, int? variantTypeId, string option, int? excludeId = null);
    }
}

using Service.DTOs.Admin.VariantTypes;
using Service.Helpers;

namespace Service.Services.Interfaces
{
    public interface IVariantTypeService
    {
        Task CreateAsync(VariantTypeCreateDto model);
        Task EditAsync(int? id, VariantTypeEditDto model);
        Task DeleteAsync(int? id);
        Task<IEnumerable<VariantTypeSelectDto>> GetAllForSelectAsync(int? excludeId = null);
        Task<PaginationResponse<VariantTypeDto>> GetPaginateAsync(int? page, int? take);
        Task<VariantTypeDto> GetByIdAsync(int? id);
        Task<bool> ExistAsync(string name, int? excludeId = null);
    }
}

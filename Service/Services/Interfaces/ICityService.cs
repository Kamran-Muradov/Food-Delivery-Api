using Service.DTOs.Admin.Cities;
using Service.Helpers;

namespace Service.Services.Interfaces
{
    public interface ICityService
    {
        Task CreateAsync(CityCreateDto model);
        Task EditAsync(int? id, CityEditDto model);
        Task DeleteAsync(int? id);
        Task<IEnumerable<CitySelectDto>> GetAllForSelectAsync(int? excludeId = null);
        Task<PaginationResponse<CityDto>> GetPaginateAsync(int? page, int? take);
        Task<CityDto> GetByIdAsync(int? id);
        Task<bool> ExistAsync(string name, int? excludeId = null);
    }
}

using Service.DTOs.Admin.Countries;
using Service.Helpers;

namespace Service.Services.Interfaces
{
    public interface ICountryService
    {
        Task CreateAsync(CountryCreateDto model);
        Task EditAsync(int? id, CountryEditDto model);
        Task DeleteAsync(int? id);
        Task<IEnumerable<CountryDto>> GetAllAsync();
        Task<IEnumerable<CountrySelectDto>> GetAllForSelectAsync(int? excludeId = null);
        Task<PaginationResponse<CountryDto>> GetPaginateAsync(int? page, int? take);
        Task<CountryDto> GetByIdAsync(int? id);
        Task<bool> ExistAsync(string name, int? excludeId = null);
    }
}

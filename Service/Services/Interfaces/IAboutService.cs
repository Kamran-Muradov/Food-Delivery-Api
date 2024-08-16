using Service.DTOs.Admin.Abouts;
using Service.Helpers;

namespace Service.Services.Interfaces
{
    public interface IAboutService
    {
        Task CreateAsync(AboutCreateDto model);
        Task EditAsync(int? id, AboutEditDto model);
        Task DeleteAsync(int? id);
        Task<PaginationResponse<AboutDto>> GetPaginateAsync(int? page, int? take);
        Task<IEnumerable<DTOs.UI.Abouts.AboutDto>> GetAllAsync();
        Task<AboutDetailDto> GetByIdAsync(int? id);
    }
}

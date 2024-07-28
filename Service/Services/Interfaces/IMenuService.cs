using Service.DTOs.Admin.Menus;
using Service.Helpers;

namespace Service.Services.Interfaces
{
    public interface IMenuService
    {
        Task CreateAsync(MenuCreateDto model);
        Task EditAsync(int? id, MenuEditDto model);
        Task DeleteAsync(int? id);
        Task<PaginationResponse<MenuDto>> GetPaginateAsync(int? page, int? take);
        Task<IEnumerable<MenuSelectDto>> GetAllForSelectAsync(int? excludeId = null);
        Task<MenuDetailDto> GetByIdDetailAsync(int? id);
    }
}

using Service.DTOs.Admin.Menus;
using Service.Helpers;

namespace Service.Services.Interfaces
{
    public interface IMenuService
    {
        Task CreateAsync(MenuCreateDto model);
        Task EditAsync(int? id, MenuEditDto model);
        Task DeleteAsync(int? id);
        Task<PaginationResponse<MenuDto>> GetPaginateAsync(int? page, int? take, string? searchText);
        Task<IEnumerable<MenuSelectDto>> GetAllForSelectAsync(int? excludeId = null);
        Task<MenuDetailDto> GetByIdDetailAsync(int? id);
        Task<DTOs.UI.Menus.MenuDetailDto> GetByIdAsync(int? id);
        Task<IEnumerable<MenuDto>> SearchByNameAndCategory(string searchText);
    }
}

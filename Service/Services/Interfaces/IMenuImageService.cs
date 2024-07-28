using Service.DTOs.Admin.Menus;

namespace Service.Services.Interfaces
{
    public interface IMenuImageService
    {
        Task<MenuImageDto> GetByMenuId(int? menuId);
    }
}

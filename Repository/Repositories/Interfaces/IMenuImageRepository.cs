using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IMenuImageRepository : IBaseRepository<MenuImage>
    {
        Task<MenuImage> GetByMenuId(int menuId);
    }
}

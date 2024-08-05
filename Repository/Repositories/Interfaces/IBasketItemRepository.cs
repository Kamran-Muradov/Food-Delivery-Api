using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IBasketItemRepository : IBaseRepository<BasketItem>
    {
        Task<IEnumerable<BasketItem>> GetAllByUserIdAsync(string userId);
        Task<BasketItem> GetByIdWithDatasAsync(int id);
        Task<BasketItem> GetByUserIdAndMenuId(string userId, int menuId);
    }
}

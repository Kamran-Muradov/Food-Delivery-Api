using Service.DTOs.UI.BasketItems;

namespace Service.Services.Interfaces
{
    public interface IBasketItemService
    {
        Task CreateAsync(BasketItemCreateDto model);
        Task ChangeCountAsync(BasketCountDto model);
        Task DeleteAsync(string userId, int? menuId);
        Task<IEnumerable<BasketItemDto>> GetAllByUserIdAsync(string userId);
        Task<bool> IsDifferentRestaurantAsync(string userId, int menuId);
        Task ResetAsync(BasketItemCreateDto model);
    }
}

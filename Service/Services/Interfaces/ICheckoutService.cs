using Service.DTOs.UI.Checkouts;

namespace Service.Services.Interfaces
{
    public interface ICheckoutService
    {
        Task CreateAsync(CheckoutCreateDto model);
        Task CreateRangeByUserIdAsync(string userId);
        Task<IEnumerable<CheckoutDto>> GetAllAsync();
    }
}

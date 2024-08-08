using Service.DTOs.UI.Checkouts;

namespace Service.Services.Interfaces
{
    public interface ICheckoutService
    {
        Task CreateAsync(CheckoutCreateDto model);
        Task CreateByUserIdAsync(string userId);
        Task<IEnumerable<CheckoutDto>> GetAllByUserIdAsync(string userId);
    }
}

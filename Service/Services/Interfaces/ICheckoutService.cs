using Service.DTOs.UI.Checkouts;

namespace Service.Services.Interfaces
{
    public interface ICheckoutService
    {
        Task CreateAsync(CheckoutCreateDto model);
        Task<IEnumerable<CheckoutDto>> GetAllAsync();
    }
}

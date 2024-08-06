using Service.DTOs.UI.Payment;
using Service.Helpers;

namespace Service.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponse> CreateCheckoutSessionAsync(PaymentDto model);
        bool CheckPaymentStatus(string sessionId);
    }
}

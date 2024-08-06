namespace Service.DTOs.UI.Payment
{
    public class PaymentDto
    {
        public string UserId { get; set; }
        public string SuccessUrl { get; set; }
        public string CancelUrl { get; set; }
        public decimal Amount { get; set; }
    }
}

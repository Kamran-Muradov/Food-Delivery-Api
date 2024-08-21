namespace Service.Helpers
{
    public class PromoCodeResponse
    {
        public bool Success { get; set; }
        public string? Error { get; set; } = null;
        public double? Discount { get; set; } = null;
    }
}

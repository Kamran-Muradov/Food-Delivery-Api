namespace Service.DTOs.UI.BasketItems
{
    public class BasketItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public decimal DeliveryFee { get; set; }
        public int MenuId { get; set; }
        public string Restaurant { get; set; }
        public string Image { get; set; }
        public string? AppliedPromoCode { get; set; }
        public Dictionary<string, List<string>>? BasketVariants { get; set; }
    }
}

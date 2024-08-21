namespace Service.DTOs.Admin.PromoCodes
{
    public class PromoCodeDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Discount { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CreatedDate { get; set; }
    }
}

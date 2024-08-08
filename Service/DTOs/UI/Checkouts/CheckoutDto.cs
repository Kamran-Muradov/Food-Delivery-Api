namespace Service.DTOs.UI.Checkouts
{
    public class CheckoutDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public string CreatedDate { get; set; }
        public string Status { get; set; }
    }
}

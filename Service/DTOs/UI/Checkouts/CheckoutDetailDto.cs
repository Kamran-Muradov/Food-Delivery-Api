using Service.DTOs.UI.Reviews;

namespace Service.DTOs.UI.Checkouts
{
    public class CheckoutDetailDto
    {
        public decimal TotalPrice { get; set; }
        public string CreatedDate { get; set; }
        public string Status { get; set; }
        public string Restaurant { get; set; }
        public ICollection<string> Items { get; set; }
        public ReviewDto Review { get; set; }
    }
}

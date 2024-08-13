using Domain.Common;

namespace Domain.Entities
{
    public class Checkout : BaseEntity
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public decimal TotalPrice { get; set; }
        public List<CheckoutMenu> CheckoutMenus { get; set; }
        public int? RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public Review Review { get; set; }
        public string Status { get; set; } = "Pending";
        public Checkout()
        {
            CheckoutMenus = new List<CheckoutMenu>();
        }
    }
}

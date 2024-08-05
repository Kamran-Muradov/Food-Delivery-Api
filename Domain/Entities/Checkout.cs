using Domain.Common;

namespace Domain.Entities
{
    public class Checkout : BaseEntity
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

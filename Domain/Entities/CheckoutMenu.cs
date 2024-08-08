using Domain.Common;

namespace Domain.Entities
{
    public class CheckoutMenu : BaseEntity
    {
        public int CheckoutId { get; set; }
        public Checkout Checkout { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}

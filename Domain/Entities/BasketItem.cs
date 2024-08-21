using Domain.Common;

namespace Domain.Entities
{
    public class BasketItem : BaseEntity
    {
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public List<BasketVariant> BasketVariants { get; set; }

        public BasketItem()
        {
            BasketVariants = new List<BasketVariant>();
        }
    }
}

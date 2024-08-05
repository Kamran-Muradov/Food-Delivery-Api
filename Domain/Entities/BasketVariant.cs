using Domain.Common;

namespace Domain.Entities
{
    public class BasketVariant : BaseEntity
    {
        public string Type { get; set; }
        public string Option { get; set; }
        public int BasketItemId { get; set; }
        public BasketItem BasketItem { get; set; }
    }
}

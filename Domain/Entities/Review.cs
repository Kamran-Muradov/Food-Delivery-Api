using Domain.Common;

namespace Domain.Entities
{
    public class Review : BaseEntity
    {
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public int CheckoutId { get; set; }
        public Checkout Checkout { get; set; }
    }
}

using Domain.Common;

namespace Domain.Entities
{
    public class RestaurantImage : BaseEntity
    {
        public string Url { get; set; }
        public string PublicId { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}

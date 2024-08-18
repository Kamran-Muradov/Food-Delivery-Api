using Domain.Common;

namespace Domain.Entities
{
    public class Favourite : BaseEntity
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}

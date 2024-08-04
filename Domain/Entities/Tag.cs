using Domain.Common;

namespace Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public TagImage TagImage { get; set; }
        public ICollection<RestaurantTag> RestaurantTags { get; set; }
    }
}

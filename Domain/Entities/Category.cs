using Domain.Common;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<RestaurantCategory> RestaurantCategories { get; set; }
        public CategoryImage CategoryImage { get; set; }
    }
}

using Domain.Common;

namespace Domain.Entities
{
    public class Restaurant : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal DeliveryFee { get; set; }
        public bool IsActive { get; set; }
        public decimal MinimumOrder { get; set; }
        public int MinDeliveryTime { get; set; }
        public string Address { get; set; }
        public double AverageRating { get; set; }
        public string? Website { get; set; }
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<RestaurantTag> RestaurantTags { get; set; }
        public ICollection<RestaurantImage> RestaurantImages { get; set; }
        public ICollection<Menu> Menus { get; set; }
    }
}

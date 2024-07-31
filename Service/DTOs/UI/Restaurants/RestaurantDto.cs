using Service.DTOs.Admin.Restaurants;
using Service.DTOs.UI.Categories;

namespace Service.DTOs.UI.Restaurants
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<RestaurantImageDto> RestaurantImages { get; set; }
        public int MinDeliveryTime { get; set; }
        public int Rating { get; set; }
        public decimal MinimumOrder { get; set; }
        public decimal DeliveryFee { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}

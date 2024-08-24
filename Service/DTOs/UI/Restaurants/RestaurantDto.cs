using Service.DTOs.Admin.Restaurants;
using Service.DTOs.UI.Tags;

namespace Service.DTOs.UI.Restaurants
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<RestaurantImageDto> RestaurantImages { get; set; }
        public int MinDeliveryTime { get; set; }
        public int Rating { get; set; }
        public double AverageRating { get; set; }
        public string Brand { get; set; }
        public int ReviewCount { get; set; }
        public decimal DeliveryFee { get; set; }
        public IEnumerable<TagDto> Tags { get; set; }
    }
}

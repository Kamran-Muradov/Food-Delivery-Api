using Service.DTOs.Admin.Restaurants;
using MenuDto = Service.DTOs.UI.Menus.MenuDto;

namespace Service.DTOs.UI.Restaurants
{
    public class RestaurantDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal DeliveryFee { get; set; }
        public bool IsActive { get; set; }
        public decimal MinimumOrder { get; set; }
        public int MinDeliveryTime { get; set; }
        public int Rating { get; set; }
        public double AverageRating { get; set; }
        public int ReviewCount { get; set; }
        public string Address { get; set; }
        public string? Website { get; set; }
        public IEnumerable<RestaurantImageDto> RestaurantImages { get; set; }
        public IEnumerable<MenuDto> Menus { get; set; }
    }
}

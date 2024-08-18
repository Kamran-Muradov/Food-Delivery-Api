using Service.DTOs.UI.Restaurants;

namespace Service.DTOs.UI.Favourites
{
    public class FavouriteDto
    {
        public int Id { get; set; }
        public RestaurantDto Restaurant { get; set; }
    }
}

using Service.DTOs.Admin.Restaurants;

namespace Service.Services.Interfaces
{
    public interface IRestaurantImageService
    {
        Task<IEnumerable<RestaurantImageDto>> GetAllByRestaurantId(int? restaurantId);
    }
}

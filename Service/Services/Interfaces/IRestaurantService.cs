using Service.DTOs.Admin.Restaurants;
using Service.DTOs.UI.Restaurants;
using Service.Helpers;
using RestaurantDto = Service.DTOs.Admin.Restaurants.RestaurantDto;

namespace Service.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task CreateAsync(RestaurantCreateDto model);
        Task EditAsync(int? id, RestaurantEditDto model);
        Task DeleteAsync(int? id);
        Task<PaginationResponse<RestaurantDto>> GetPaginateAsync(int? page, int? take);
        Task<IEnumerable<DTOs.UI.Restaurants.RestaurantDto>> GetAllWithImagesAsync();
        Task<PaginationResponse<DTOs.UI.Restaurants.RestaurantDto>> GetLoadMoreAsync(RestaurantFilterDto model);
        Task<IEnumerable<RestaurantSelectDto>> GetAllForSelectAsync(int? excludeId = null);
        Task<IEnumerable<DTOs.UI.Restaurants.RestaurantDto>> SearchByNameAndCategory(string searchText);
        Task<RestaurantDetailDto> GetByIdDetailAsync(int? id);
        Task SetMainImageAsync(MainAndDeleteImageDto model);
        Task DeleteImageAsync(MainAndDeleteImageDto model);
    }
}

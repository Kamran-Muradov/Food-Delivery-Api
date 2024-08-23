using Service.DTOs.Admin.Restaurants;
using Service.DTOs.UI.Restaurants;
using Service.Helpers;
using RestaurantDetailDto = Service.DTOs.Admin.Restaurants.RestaurantDetailDto;
using RestaurantDto = Service.DTOs.Admin.Restaurants.RestaurantDto;

namespace Service.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task CreateAsync(RestaurantCreateDto model);
        Task EditAsync(int? id, RestaurantEditDto model);
        Task DeleteAsync(int? id);
        Task<PaginationResponse<RestaurantDto>> GetPaginateAsync(int? page, int? take, string? searchText);
        Task<IEnumerable<DTOs.UI.Restaurants.RestaurantDto>> GetAllWithImagesAsync();
        Task<IEnumerable<DTOs.UI.Restaurants.RestaurantDto>> GetAllByTagIdAsync(int? tagId);
        Task<IEnumerable<DTOs.UI.Restaurants.RestaurantDto>> GetAllByBrandIdAsync(int brandId);
        Task<PaginationResponse<DTOs.UI.Restaurants.RestaurantDto>> GetAllFilteredAsync(RestaurantFilterDto model);
        Task<IEnumerable<RestaurantSelectDto>> GetAllForSelectAsync(int? excludeId = null);
        Task<IEnumerable<DTOs.UI.Restaurants.RestaurantDto>> SearchByNameAndCategory(string searchText);
        Task<RestaurantDetailDto> GetByIdDetailAsync(int? id);
        Task<DTOs.UI.Restaurants.RestaurantDetailDto> GetByIdAsync(int? id);
        Task SetMainImageAsync(MainAndDeleteImageDto model);
        Task DeleteImageAsync(MainAndDeleteImageDto model);
    }
}

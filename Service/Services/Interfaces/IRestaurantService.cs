using Service.DTOs.Admin.Restaurants;
using Service.Helpers;

namespace Service.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task CreateAsync(RestaurantCreateDto model);
        Task EditAsync(int? id, RestaurantEditDto model);
        Task DeleteAsync(int? id);
        Task<PaginationResponse<RestaurantDto>> GetPaginateAsync(int? page, int? take);
        Task<RestaurantDetailDto> GetByIdDetailAsync(int? id);
        Task SetMainImageAsync(MainAndDeleteImageDto model);
        Task DeleteImageAsync(MainAndDeleteImageDto model);
    }
}

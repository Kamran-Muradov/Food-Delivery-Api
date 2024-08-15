using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IRestaurantRepository : IBaseRepository<Restaurant>
    {
        Task<IEnumerable<Restaurant>> GetPaginateDatasAsync(int page, int take);
        Task<IEnumerable<Restaurant>> GetAllFilteredAsync(int page, int take, string sorting, List<int>? categoryIds);
        Task<IEnumerable<Restaurant>> GetAllByBrandNameAsync(string brandName);
        Task<IEnumerable<Restaurant>> GetAllByTagIdAsync(int tagId);
        Task<IEnumerable<Restaurant>> GetAllWithImagesAsync();
        Task<Restaurant?> GetByIdWithAllDatasAsync(int id);
        Task<Restaurant> GetByIdWithImagesAsync(int id);
        Task<IEnumerable<Restaurant>> SearchByNameAndCategory(string searchText);
    }
}

using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IRestaurantRepository : IBaseRepository<Restaurant>
    {
        Task<IEnumerable<Restaurant>> GetPaginateDatasAsync(int page, int take);
        Task<IEnumerable<Restaurant>> GetAllWithImagesAsync();
        Task<Restaurant> GetByIdWithAllDatasAsync(int id);
        Task<Restaurant> GetByIdWithImagesAsync(int id);
        Task<Restaurant> GetByIdWithMenusAsync(int id);
    }
}

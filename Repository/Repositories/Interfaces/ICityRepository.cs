using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface ICityRepository : IBaseRepository<City>
    {
        Task<IEnumerable<City>> GetPaginateDatasAsync(int page, int take);
        Task<City> GetByIdWithCountryAsync(int id);
        Task<bool> ExistAsync(string name, int? excludeId = null);
    }
}

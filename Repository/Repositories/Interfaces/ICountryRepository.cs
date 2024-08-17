using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Task<IEnumerable<Country>> GetPaginateDatasAsync(int page, int take);
        Task<bool> ExistAsync(string name, int? excludeId = null);
    }
}

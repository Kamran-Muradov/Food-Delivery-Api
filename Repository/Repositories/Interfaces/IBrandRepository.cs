using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IBrandRepository : IBaseRepository<Brand>
    {
        Task<IEnumerable<Brand>> GetPaginateDatasAsync(int page, int take);
        Task<IEnumerable<Brand>> GetAllWithLogoAsync();
        Task<Brand> GetByIdWithLogoAsync(int id);
        Task<bool> ExistAsync(string name, int? excludeId = null);
    }
}

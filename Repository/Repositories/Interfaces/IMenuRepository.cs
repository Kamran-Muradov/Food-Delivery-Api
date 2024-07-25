using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IMenuRepository : IBaseRepository<Menu>
    {
        Task<IEnumerable<Menu>> GetPaginateDatasAsync(int page, int take);
        Task<Menu> GetByIdWithAllDatasAsync(int id);
        Task<Menu> GetByIdWithImageAsync(int id);
    }
}

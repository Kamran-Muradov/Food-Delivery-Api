using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<IEnumerable<Category>> GetPaginateDatasAsync(int page, int take);
        Task<IEnumerable<Category>> GetAllWithImageAsync();
        Task<Category> GetByIdWithImageAsync(int id);
        Task<Category> GetByNameAsync(string name);
    }
}

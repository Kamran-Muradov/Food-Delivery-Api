using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category> GetByNameAsync(string name);
    }
}

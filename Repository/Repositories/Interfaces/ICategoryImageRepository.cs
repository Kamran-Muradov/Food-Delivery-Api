using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface ICategoryImageRepository : IBaseRepository<CategoryImage>
    {
        Task<CategoryImage> GetByCategoryIdAsync(int categoryId);
    }
}

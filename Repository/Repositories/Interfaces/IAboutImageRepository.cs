using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IAboutImageRepository : IBaseRepository<AboutImage>
    {
        Task<AboutImage> GetByAboutIdAsync(int aboutId);
    }
}

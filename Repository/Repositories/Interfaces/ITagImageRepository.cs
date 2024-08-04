using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface ITagImageRepository : IBaseRepository<TagImage>
    {
        Task<TagImage> GetByTagIdAsync(int tagId);
    }
}

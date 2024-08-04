using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        Task<IEnumerable<Tag>> GetPaginateDatasAsync(int page, int take);
        Task<IEnumerable<Tag>> GetAllWithImageAsync();
        Task<Tag> GetByIdWithImageAsync(int id);
        Task<Tag> GetByNameAsync(string name);
        Task<bool> ExistAsync(string name, int? excludeId = null);
    }
}

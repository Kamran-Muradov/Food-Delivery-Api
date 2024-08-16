using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IAboutRepository : IBaseRepository<About>
    {
        Task<IEnumerable<About>> GetAllWithImagesAsync();
        Task<IEnumerable<About>> GetPaginateDatasAsync(int page, int take);
        Task<About> GetByIdWithImageAsync(int id);
    }
}

using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetPaginateDatasAsync(int page, int take);
    }
}

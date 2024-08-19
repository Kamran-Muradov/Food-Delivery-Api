using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IVariantTypeRepository : IBaseRepository<VariantType>
    {
        Task<IEnumerable<VariantType>> GetPaginateDatasAsync(int page, int take);
        Task<bool> ExistAsync(string name, int? excludeId = null);
    }
}

using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IMenuVariantRepository : IBaseRepository<MenuVariant>
    {
        Task<IEnumerable<MenuVariant>> GetPaginateDatasAsync(int page, int take);
        Task<MenuVariant> GetByIdWithAllDatasAsync(int id);
        Task<Dictionary<string, IEnumerable<MenuVariant>>> GetAllByMenuIdGroupedAsync(int menuId);
        Task<bool> ExistAsync(int menuId, int variantTypeId, string option, int? excludeId = null);
    }
}

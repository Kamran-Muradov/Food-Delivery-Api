using Service.DTOs.Admin.VariantTypes;

namespace Service.Services.Interfaces
{
    public interface IVariantTypeService
    {
        Task<IEnumerable<VariantTypeSelectDto>> GetAllForSelectAsync(int? excludeId = null);
    }
}

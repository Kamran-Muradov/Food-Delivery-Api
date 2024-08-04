using Service.DTOs.Admin.Tags;
using Service.Helpers;
using TagDto = Service.DTOs.UI.Tags.TagDto;

namespace Service.Services.Interfaces
{
    public interface ITagService
    {
        Task CreateAsync(TagCreateDto model);
        Task EditAsync(int? id, TagEditDto model);
        Task DeleteAsync(int? id);
        Task<IEnumerable<TagDto>> GetAllAsync();
        Task<IEnumerable<TagSelectDto>> GetAllForSelectAsync(int? excludeId = null);
        Task<PaginationResponse<DTOs.Admin.Tags.TagDto>> GetPaginateAsync(int? page, int? take);
        Task<TagDto> GetByIdAsync(int? id);
        Task<bool> ExistAsync(string name, int? excludeId = null);
    }
}

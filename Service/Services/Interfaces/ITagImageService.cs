using Service.DTOs.Admin.Tags;

namespace Service.Services.Interfaces
{
    public interface ITagImageService
    {
        Task<TagImageDto> GetByTagIdAsync(int? tagId);
    }
}

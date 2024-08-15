using Service.DTOs.Admin.SocialMedias;

namespace Service.Services.Interfaces
{
    public interface ISocialMediaService
    {
        Task CreateAsync(SocialMediaCreateDto model);
        Task EditAsync(int? id, SocialMediaEditDto model);
        Task DeleteAsync(int? id);
        Task<IEnumerable<SocialMediaDto>> GetWithAllDatasAsync();
        Task<IEnumerable<DTOs.UI.SocialMedias.SocialMediaDto>> GetAllAsync();
        Task<SocialMediaDto> GetByIdAsync(int? id);
    }
}

using Service.DTOs.Admin.Abouts;

namespace Service.Services.Interfaces
{
    public interface IAboutImageService
    {
        Task<AboutImageDto> GetByAboutIdAsync(int? aboutId);
    }
}

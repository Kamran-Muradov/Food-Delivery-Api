using Service.DTOs.Admin.Sliders;

namespace Service.Services.Interfaces
{
    public interface ISliderImageService
    {
        Task<SliderImageDto> GetBySliderIdAsync(int? sliderId);
    }
}

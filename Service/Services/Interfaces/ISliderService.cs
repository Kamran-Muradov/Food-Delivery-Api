using Service.DTOs.Admin.Sliders;
using Service.Helpers;

namespace Service.Services.Interfaces
{
    public interface ISliderService
    {
        Task CreateAsync(SliderCreateDto model);
        Task EditAsync(int? id, SliderEditDto model);
        Task DeleteAsync(int? id);
        Task<PaginationResponse<SliderDto>> GetPaginateAsync(int? page, int? take);
        Task<IEnumerable<DTOs.UI.Sliders.SliderDto>> GetAllAsync();
        Task<SliderDetailDto> GetByIdAsync(int? id);
    }
}

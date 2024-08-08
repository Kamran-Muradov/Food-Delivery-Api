using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface ISliderImageRepository : IBaseRepository<SliderImage>
    {
        Task<SliderImage> GetBySliderIdAsync(int sliderId);
    }
}

using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface ISliderRepository : IBaseRepository<Slider>
    {
        Task<IEnumerable<Slider>> GetAllWithImagesAsync();
        Task<IEnumerable<Slider>> GetPaginateDatasAsync(int page, int take);
        Task<Slider> GetByIdWithImageAsync(int id);
    }
}

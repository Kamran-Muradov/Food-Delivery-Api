using Service.DTOs.UI.Reviews;

namespace Service.Services.Interfaces
{
    public interface IReviewService
    {
        Task CreateAsync(ReviewCreateDto model);
        Task<IEnumerable<ReviewDto>> GetAllAsync();
    }
}

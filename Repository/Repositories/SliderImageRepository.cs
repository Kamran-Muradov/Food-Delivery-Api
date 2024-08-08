using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class SliderImageRepository : BaseRepository<SliderImage>, ISliderImageRepository
    {
        public SliderImageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<SliderImage> GetBySliderIdAsync(int sliderId)
        {
            return await Entities
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.SliderId == sliderId);
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class SliderRepository : BaseRepository<Slider>, ISliderRepository
    {
        public SliderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Slider>> GetPaginateDatasAsync(int page, int take)
        {
            return await Entities
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .Include(m => m.SliderImage)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Slider>> GetAllWithImagesAsync()
        {
            return await Entities
                .Include(s => s.SliderImage)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Slider> GetByIdWithImageAsync(int id)
        {
            return await Entities
                .Where(s => s.Id == id)
                .Include(s => s.SliderImage)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}

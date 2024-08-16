using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class AboutRepository : BaseRepository<About>, IAboutRepository
    {
        public AboutRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<About>> GetPaginateDatasAsync(int page, int take)
        {
            return await Entities
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .Include(m => m.AboutImage)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<About>> GetAllWithImagesAsync()
        {
            return await Entities
                .OrderByDescending(m => m.Id)
                .Include(s => s.AboutImage)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<About> GetByIdWithImageAsync(int id)
        {
            return await Entities
                .Where(s => s.Id == id)
                .Include(s => s.AboutImage)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}

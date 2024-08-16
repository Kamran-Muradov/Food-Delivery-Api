using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class AboutImageRepository : BaseRepository<AboutImage>, IAboutImageRepository
    {
        public AboutImageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<AboutImage> GetByAboutIdAsync(int aboutId)
        {
            return await Entities
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AboutId == aboutId);
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class TagImageRepository : BaseRepository<TagImage>, ITagImageRepository
    {
        public TagImageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<TagImage> GetByTagIdAsync(int tagId)
        {
            return await Entities
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TagId == tagId);
        }
    }
}

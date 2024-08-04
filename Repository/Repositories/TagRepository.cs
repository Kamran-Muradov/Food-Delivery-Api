using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Tag>> GetPaginateDatasAsync(int page, int take)
        {
            return await Entities
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .Include(m => m.TagImage)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Tag>> GetAllWithImageAsync()
        {
            return await Entities
                .Include(m => m.TagImage)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Tag> GetByIdWithImageAsync(int id)
        {
            return await Entities
                .Where(m => m.Id == id)
                .Include(m => m.TagImage)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Tag> GetByNameAsync(string name)
        {
            return await Entities.AsNoTracking().FirstOrDefaultAsync(m => m.Name == name);
        }

        public async Task<bool> ExistAsync(string name, int? excludeId = null)
        {
            return await Entities
                .Where(m => m.Id != excludeId)
                .AnyAsync(m => m.Name == name);
        }
    }
}

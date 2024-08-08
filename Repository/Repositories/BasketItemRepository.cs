using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class BasketItemRepository : BaseRepository<BasketItem>, IBasketItemRepository
    {
        public BasketItemRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BasketItem>> GetAllByUserIdAsync(string userId)
        {
            return await Entities
                .Where(bi => bi.UserId == userId)
                .Include(bi => bi.Menu)
                .ThenInclude(m => m.Restaurant)
                .Include(bi => bi.Menu)
                .ThenInclude(m => m.MenuImage)
                .Include(bi => bi.User)
                .Include(bi => bi.BasketVariants)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<BasketItem> GetByIdWithDatasAsync(int id)
        {
            return await Entities
                .Where(bi => bi.Id == id)
                .Include(bi => bi.Menu)
                .ThenInclude(m => m.Restaurant)
                .Include(bi => bi.User)
                .Include(bi => bi.BasketVariants)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<BasketItem> GetByUserIdAndMenuId(string userId, int menuId)
        {
            return await Entities
                .Where(bi => bi.UserId == userId && bi.MenuId == menuId)
                .Include(bi => bi.BasketVariants)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}

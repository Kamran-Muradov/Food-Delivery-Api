using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class MenuImageRepository : BaseRepository<MenuImage>, IMenuImageRepository
    {
        public MenuImageRepository(AppDbContext context) : base(context) { }
        public async Task<MenuImage> GetByMenuId(int menuId)
        {
            return await Entities
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.MenuId == menuId);
        }
    }
}

using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class MenuImageRepository : BaseRepository<MenuImage>, IMenuImageRepository
    {
        public MenuImageRepository(AppDbContext context) : base(context) { }
    }
}

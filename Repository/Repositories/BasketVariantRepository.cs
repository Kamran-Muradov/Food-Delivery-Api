using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class BasketVariantRepository : BaseRepository<BasketVariant>, IBasketVariantRepository
    {
        public BasketVariantRepository(AppDbContext context) : base(context)
        {
        }
    }
}

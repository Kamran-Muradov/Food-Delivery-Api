using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class VariantTypeRepository : BaseRepository<VariantType>, IVariantTypeRepository
    {
        public VariantTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}

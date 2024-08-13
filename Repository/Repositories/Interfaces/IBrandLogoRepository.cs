using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IBrandLogoRepository : IBaseRepository<BrandLogo>
    {
        Task<BrandLogo> GetByBrandIdAsync(int brandId);

    }
}

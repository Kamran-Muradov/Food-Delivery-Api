using Service.DTOs.Admin.Brands;

namespace Service.Services.Interfaces
{
    public interface IBrandLogoService
    {
        Task<BrandLogoDto> GetByBrandIdAsync(int? brandId);
    }
}

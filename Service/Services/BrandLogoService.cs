using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Brands;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class BrandLogoService : IBrandLogoService
    {
        private readonly IBrandLogoRepository _brandLogoRepository;
        private readonly IMapper _mapper;

        public BrandLogoService(IBrandLogoRepository brandLogoRepository, 
                                IMapper mapper)
        {
            _brandLogoRepository = brandLogoRepository;
            _mapper = mapper;
        }

        public async Task<BrandLogoDto> GetByBrandIdAsync(int? brandId)
        {
            ArgumentNullException.ThrowIfNull(brandId);
            return _mapper.Map<BrandLogoDto>(await _brandLogoRepository.GetByBrandIdAsync((int)brandId));        }
    }
}

using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Brands;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
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
            var brandLogo = await _brandLogoRepository.GetByBrandIdAsync((int)brandId) ??
                            throw new NotFoundException(ResponseMessages.NotFound);

            return _mapper.Map<BrandLogoDto>(brandLogo);        }
    }
}

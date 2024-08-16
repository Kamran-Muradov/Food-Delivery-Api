using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Abouts;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class AboutImageService : IAboutImageService
    {
        private readonly IAboutImageRepository _aboutImageRepository;
        private readonly IMapper _mapper;

        public AboutImageService(IAboutImageRepository aboutImageRepository, 
                                 IMapper mapper)
        {
            _aboutImageRepository = aboutImageRepository;
            _mapper = mapper;
        }

        public async Task<AboutImageDto> GetByAboutIdAsync(int? aboutId)
        {
            ArgumentNullException.ThrowIfNull(aboutId);
            return _mapper.Map<AboutImageDto>(await _aboutImageRepository.GetByAboutIdAsync((int)aboutId));
        }
    }
}

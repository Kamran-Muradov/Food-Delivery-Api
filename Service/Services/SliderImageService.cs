using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Sliders;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class SliderImageService : ISliderImageService
    {
        private readonly ISliderImageRepository _sliderImageRepository;
        private readonly IMapper _mapper;

        public SliderImageService(ISliderImageRepository sliderImageRepository, 
            IMapper mapper)
        {
            _sliderImageRepository = sliderImageRepository;
            _mapper = mapper;
        }

        public async Task<SliderImageDto> GetBySliderIdAsync(int? sliderId)
        {
            ArgumentNullException.ThrowIfNull(sliderId);
            return _mapper.Map<SliderImageDto>(await _sliderImageRepository.GetBySliderIdAsync((int)sliderId));
        }
    }
}

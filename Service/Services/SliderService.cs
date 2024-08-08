using AutoMapper;
using CloudinaryDotNet.Actions;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Sliders;
using Service.Helpers;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly ISliderImageRepository _sliderImageRepository;

        public SliderService(ISliderRepository sliderRepository,
                             IMapper mapper,
                             IPhotoService photoService,
                             ISliderImageRepository sliderImageRepository)
        {
            _sliderRepository = sliderRepository;
            _mapper = mapper;
            _photoService = photoService;
            _sliderImageRepository = sliderImageRepository;
        }

        public async Task CreateAsync(SliderCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            Slider slider = _mapper.Map<Slider>(model);

            ImageUploadResult uploadResult = await _photoService.AddPhoto(model.Image);

            SliderImage sliderImage = new()
            {
                Url = uploadResult.SecureUrl.ToString(),
                PublicId = uploadResult.PublicId,
                SliderId = slider.Id
            };

            slider.SliderImage = sliderImage;

            await _sliderRepository.CreateAsync(slider);
        }

        public async Task EditAsync(int? id, SliderEditDto model)
        {
            ArgumentNullException.ThrowIfNull(id);
            ArgumentNullException.ThrowIfNull(model);

            var slider = await _sliderRepository.GetByIdWithImageAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            if (model.Image is not null)
            {
                await _photoService.DeletePhoto(slider.SliderImage.PublicId);
                await _sliderImageRepository.DeleteAsync(slider.SliderImage);

                ImageUploadResult uploadResult = await _photoService.AddPhoto(model.Image);

                SliderImage sliderImage = new()
                {
                    Url = uploadResult.SecureUrl.ToString(),
                    PublicId = uploadResult.PublicId,
                    SliderId = slider.Id
                };

                slider.SliderImage = sliderImage;
            }

            slider.UpdatedDate = DateTime.Now;
            await _sliderRepository.EditAsync(_mapper.Map(model, slider));
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var slider = await _sliderRepository.GetByIdWithImageAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            await _photoService.DeletePhoto(slider.SliderImage.PublicId);

            await _sliderRepository.DeleteAsync(slider);
        }

        public async Task<PaginationResponse<SliderDto>> GetPaginateAsync(int? page, int? take)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            var sliders = await _sliderRepository.GetAllAsync();
            int totalPage = (int)Math.Ceiling((decimal)sliders.Count() / (int)take);

            var mappedDatas = _mapper.Map<IEnumerable<SliderDto>>(await _sliderRepository.GetPaginateDatasAsync((int)page, (int)take));

            return new PaginationResponse<SliderDto>(mappedDatas, totalPage, (int)page);
        }

        public async Task<SliderDetailDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return _mapper.Map<SliderDetailDto>(await _sliderRepository.GetByIdAsync((int)id));
        }
    }
}

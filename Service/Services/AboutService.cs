using AutoMapper;
using CloudinaryDotNet.Actions;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Abouts;
using Service.Helpers;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using AboutDto = Service.DTOs.Admin.Abouts.AboutDto;

namespace Service.Services
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly IAboutImageRepository _aboutImageRepository;

        public AboutService(IAboutRepository aboutRepository,
                            IMapper mapper,
                            IPhotoService photoService,
                            IAboutImageRepository aboutImageRepository)
        {
            _aboutRepository = aboutRepository;
            _mapper = mapper;
            _photoService = photoService;
            _aboutImageRepository = aboutImageRepository;
        }

        public async Task CreateAsync(AboutCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            About about = _mapper.Map<About>(model);

            ImageUploadResult uploadResult = await _photoService.AddPhoto(model.Image);

            AboutImage aboutImage = new()
            {
                Url = uploadResult.SecureUrl.ToString(),
                PublicId = uploadResult.PublicId,
                AboutId = about.Id
            };

            about.AboutImage = aboutImage;

            await _aboutRepository.CreateAsync(about);
        }

        public async Task EditAsync(int? id, AboutEditDto model)
        {
            ArgumentNullException.ThrowIfNull(id);
            ArgumentNullException.ThrowIfNull(model);

            var about = await _aboutRepository.GetByIdWithImageAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            if (model.Image is not null)
            {
                await _photoService.DeletePhoto(about.AboutImage.PublicId);
                await _aboutImageRepository.DeleteAsync(about.AboutImage);

                ImageUploadResult uploadResult = await _photoService.AddPhoto(model.Image);

                AboutImage aboutImage = new()
                {
                    Url = uploadResult.SecureUrl.ToString(),
                    PublicId = uploadResult.PublicId,
                    AboutId = about.Id
                };
                about.AboutImage = aboutImage;
            }

            about.UpdatedDate = DateTime.Now;
            await _aboutRepository.EditAsync(_mapper.Map(model, about));
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var about = await _aboutRepository.GetByIdWithImageAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            await _photoService.DeletePhoto(about.AboutImage.PublicId);

            await _aboutRepository.DeleteAsync(about);
        }

        public async Task<PaginationResponse<AboutDto>> GetPaginateAsync(int? page, int? take)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            var sliders = await _aboutRepository.GetAllAsync();
            int totalPage = (int)Math.Ceiling((decimal)sliders.Count() / (int)take);
            
            var mappedDatas = _mapper.Map<IEnumerable<AboutDto>>(await _aboutRepository.GetPaginateDatasAsync((int)page, (int)take));

            return new PaginationResponse<AboutDto>(mappedDatas, totalPage, (int)page);
        }

        public async Task<IEnumerable<DTOs.UI.Abouts.AboutDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<DTOs.UI.Abouts.AboutDto>>(await _aboutRepository.GetAllWithImagesAsync());
        }

        public async Task<AboutDetailDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return _mapper.Map<AboutDetailDto>(await _aboutRepository.GetByIdAsync((int)id));
        }
    }
}

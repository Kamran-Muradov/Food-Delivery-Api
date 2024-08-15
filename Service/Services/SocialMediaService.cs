using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.SocialMedias;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IMapper _mapper;

        public SocialMediaService(ISocialMediaRepository socialMediaRepository,
                                  IMapper mapper)
        {
            _socialMediaRepository = socialMediaRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(SocialMediaCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);
            await _socialMediaRepository.CreateAsync(_mapper.Map<SocialMedia>(model));
        }

        public async Task EditAsync(int? id, SocialMediaEditDto model)
        {
            ArgumentNullException.ThrowIfNull(id);
            ArgumentNullException.ThrowIfNull(model);

            var socialMedia = await _socialMediaRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            await _socialMediaRepository.EditAsync(_mapper.Map(model, socialMedia));
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            var socialMedia = await _socialMediaRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);
            await _socialMediaRepository.DeleteAsync(socialMedia);
        }

        public async Task<IEnumerable<SocialMediaDto>> GetWithAllDatasAsync()
        {
            var socialMedias = await _socialMediaRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<SocialMediaDto>>(socialMedias.OrderByDescending(sm => sm.Id));
        }

        public async Task<IEnumerable<DTOs.UI.SocialMedias.SocialMediaDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<DTOs.UI.SocialMedias.SocialMediaDto>>(await _socialMediaRepository.GetAllAsync());
        }

        public async Task<SocialMediaDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return _mapper.Map<SocialMediaDto>(await _socialMediaRepository.GetByIdAsync((int)id));

        }
    }
}

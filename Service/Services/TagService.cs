using AutoMapper;
using CloudinaryDotNet.Actions;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Tags;
using Service.Helpers;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly ITagImageRepository _tagImageRepository;
        private readonly IRestaurantTagRepository _restaurantTagRepository;

        public TagService(ITagRepository tagRepository,
                               IMapper mapper,
                               IPhotoService photoService,
                               ITagImageRepository tagImageRepository, 
                               IRestaurantTagRepository restaurantTagRepository)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
            _photoService = photoService;
            _tagImageRepository = tagImageRepository;
            _restaurantTagRepository = restaurantTagRepository;
        }

        public async Task CreateAsync(TagCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            if (!await _tagRepository.ExistAsync(model.Name))
            {
                Tag tag = _mapper.Map<Tag>(model);

                ImageUploadResult uploadResult = await _photoService.AddPhoto(model.Image);

                TagImage tagImage = new()
                {
                    Url = uploadResult.SecureUrl.ToString(),
                    PublicId = uploadResult.PublicId,
                    TagId = tag.Id
                };

                tag.TagImage = tagImage;

                await _tagRepository.CreateAsync(tag);
            }
        }

        public async Task EditAsync(int? id, TagEditDto model)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(model);

            var tag = await _tagRepository.GetByIdWithImageAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            if (!await _tagRepository.ExistAsync(model.Name, id))
            {
                if (model.Image is not null)
                {
                    await _photoService.DeletePhoto(tag.TagImage.PublicId);
                    await _tagImageRepository.DeleteAsync(tag.TagImage);

                    ImageUploadResult uploadResult = await _photoService.AddPhoto(model.Image);

                    TagImage categoryImage = new()
                    {
                        Url = uploadResult.SecureUrl.ToString(),
                        PublicId = uploadResult.PublicId,
                        TagId = tag.Id
                    };

                    tag.TagImage = categoryImage;
                }

                tag.UpdatedDate = DateTime.Now;
                await _tagRepository.EditAsync(_mapper.Map(model, tag));
            }
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var tag = await _tagRepository.GetByIdWithImageAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            await _photoService.DeletePhoto(tag.TagImage.PublicId);

            await _tagRepository.DeleteAsync(tag);
        }

        public async Task<IEnumerable<TagSelectDto>> GetAllForSelectAsync(int? excludeId = null)
        {
            var tagIds = _restaurantTagRepository
                .GetAllWithExpressionAsync(m => m.RestaurantId == excludeId).Result
                .Select(m => m.TagId);

            var tags = _tagRepository
                .GetAllAsync().Result
                .Where(m => !tagIds.Contains(m.Id))
                .OrderBy(m => m.Name);

            return _mapper.Map<IEnumerable<TagSelectDto>>(tags);
        }

        public async Task<PaginationResponse<TagDto>> GetPaginateAsync(int? page, int? take)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            var tags = await _tagRepository.GetAllAsync();
            int totalPage = (int)Math.Ceiling((decimal)tags.Count() / (int)take);

            var mappedDatas = _mapper.Map<IEnumerable<TagDto>>(await _tagRepository.GetPaginateDatasAsync((int)page, (int)take));

            return new PaginationResponse<TagDto>(mappedDatas, totalPage, (int)page);
        }

        public async Task<IEnumerable<DTOs.UI.Tags.TagDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<DTOs.UI.Tags.TagDto>>(await _tagRepository.GetAllWithImageAsync());
        }

        public async Task<DTOs.UI.Tags.TagDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            return _mapper.Map<DTOs.UI.Tags.TagDto>(await _tagRepository.GetByIdAsync((int)id));
        }

        public async Task<bool> ExistAsync(string name, int? excludeId = null)
        {
            ArgumentNullException.ThrowIfNull(name);

            return await _tagRepository.ExistAsync(name, excludeId);
        }
    }
}

using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Tags;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class TagImageService : ITagImageService
    {
        private readonly ITagImageRepository _tagImageRepository;
        private readonly IMapper _mapper;

        public TagImageService(ITagImageRepository tagImageRepository, 
            IMapper mapper)
        {
            _tagImageRepository = tagImageRepository;
            _mapper = mapper;
        }

        public async Task<TagImageDto> GetByTagIdAsync(int? tagId)
        {
            ArgumentNullException.ThrowIfNull(tagId);
            return _mapper.Map<TagImageDto>(await _tagImageRepository.GetByTagIdAsync((int)tagId));
        }
    }
}

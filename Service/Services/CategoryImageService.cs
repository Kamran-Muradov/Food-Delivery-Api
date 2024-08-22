using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Categories;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class CategoryImageService : ICategoryImageService
    {
        private readonly ICategoryImageRepository _categoryImageRepository;
        private readonly IMapper _mapper;

        public CategoryImageService(ICategoryImageRepository categoryImageRepository,
                                    IMapper mapper)
        {
            _categoryImageRepository = categoryImageRepository;
            _mapper = mapper;
        }

        public async Task<CategoryImageDto> GetByCategoryIdAsync(int? categoryId)
        {
            ArgumentNullException.ThrowIfNull(categoryId);
            var categoryImage = await _categoryImageRepository.GetByCategoryIdAsync((int)categoryId) ??
                                throw new NotFoundException(ResponseMessages.NotFound);

            return _mapper.Map<CategoryImageDto>(categoryImage);
        }
    }
}

using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Categories;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CategoryCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            if (await _categoryRepository.GetByNameAsync(model.Name) is not null)
            {
                throw new BadRequestException(ResponseMessages.ExistData);
            }

            await _categoryRepository.CreateAsync(_mapper.Map<Category>(model));
        }

        public async Task EditAsync(int? id, CategoryEditDto model)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(model);

            var ingredient = await _categoryRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            if (ingredient.Id != id && await _categoryRepository.GetByNameAsync(model.Name) is not null)
            {
                throw new BadRequestException(ResponseMessages.ExistData);
            }

            ingredient.UpdatedDate = DateTime.Now;
            await _categoryRepository.EditAsync(_mapper.Map(model, ingredient));
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var ingredient = await _categoryRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            await _categoryRepository.DeleteAsync(ingredient);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _categoryRepository.GetAllAsync());
        }

        public async Task<CategoryDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            return _mapper.Map<CategoryDto>(await _categoryRepository.GetByIdAsync((int)id));
        }
    }
}

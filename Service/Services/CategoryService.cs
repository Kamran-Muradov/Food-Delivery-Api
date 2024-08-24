using AutoMapper;
using CloudinaryDotNet.Actions;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Categories;
using Service.Helpers;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using CategoryDto = Service.DTOs.UI.Categories.CategoryDto;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly ICategoryImageRepository _categoryImageRepository;

        public CategoryService(ICategoryRepository categoryRepository,
                               IMapper mapper,
                               IPhotoService photoService,
                               ICategoryImageRepository categoryImageRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _photoService = photoService;
            _categoryImageRepository = categoryImageRepository;
        }

        public async Task CreateAsync(CategoryCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            if (!await _categoryRepository.ExistAsync(model.Name))
            {
                Category category = _mapper.Map<Category>(model);

                ImageUploadResult uploadResult = await _photoService.AddPhoto(model.Image);

                CategoryImage categoryImage = new()
                {
                    Url = uploadResult.SecureUrl.ToString(),
                    PublicId = uploadResult.PublicId,
                    CategoryId = category.Id
                };

                category.CategoryImage = categoryImage;

                await _categoryRepository.CreateAsync(category);
            }
        }

        public async Task EditAsync(int? id, CategoryEditDto model)
        {
            ArgumentNullException.ThrowIfNull(id);
            ArgumentNullException.ThrowIfNull(model);

            var category = await _categoryRepository.GetByIdWithImageAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            if (!await _categoryRepository.ExistAsync(model.Name, id))
            {
                if (model.Image is not null)
                {
                    await _photoService.DeletePhoto(category.CategoryImage.PublicId);
                    await _categoryImageRepository.DeleteAsync(category.CategoryImage);

                    ImageUploadResult uploadResult = await _photoService.AddPhoto(model.Image);

                    CategoryImage categoryImage = new()
                    {
                        Url = uploadResult.SecureUrl.ToString(),
                        PublicId = uploadResult.PublicId,
                        CategoryId = category.Id
                    };

                    category.CategoryImage = categoryImage;
                }

                category.UpdatedDate = DateTime.Now;
                await _categoryRepository.EditAsync(_mapper.Map(model, category));
            }
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var category = await _categoryRepository.GetByIdWithImageAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            await _photoService.DeletePhoto(category.CategoryImage.PublicId);

            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<IEnumerable<CategorySelectDto>> GetAllForSelectAsync(int? excludeId = null)
        {
            var categories = await _categoryRepository.GetAllWithExpressionAsync(r => r.Menus.All(m => m.Id != excludeId));
            return _mapper.Map<IEnumerable<CategorySelectDto>>(categories.OrderBy(m => m.Name));
        }

        public async Task<PaginationResponse<DTOs.Admin.Categories.CategoryDto>> GetPaginateAsync(int? page, int? take, string? searchText)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            IEnumerable<Category> categories;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                categories = await _categoryRepository.GetAllAsync();
            }
            else
            {
                categories = await _categoryRepository.GetAllWithExpressionAsync(m => m.Name.Contains(searchText));
            }

            int totalPage = (int)Math.Ceiling((decimal)categories.Count() / (int)take);

            var mappedDatas = _mapper.Map<IEnumerable<DTOs.Admin.Categories.CategoryDto>>(await _categoryRepository.GetPaginateDatasAsync((int)page, (int)take, searchText));

            return new PaginationResponse<DTOs.Admin.Categories.CategoryDto>(mappedDatas, totalPage, (int)page);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _categoryRepository.GetAllWithImageAsync());
        }

        public async Task<DTOs.Admin.Categories.CategoryDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            var category = await _categoryRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            return _mapper.Map<DTOs.Admin.Categories.CategoryDto>(category);
        }

        public async Task<bool> ExistAsync(string name, int? excludeId = null)
        {
            ArgumentNullException.ThrowIfNull(name);
            return await _categoryRepository.ExistAsync(name, excludeId);
        }
    }
}

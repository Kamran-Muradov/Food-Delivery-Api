using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Ingredients;
using Service.Helpers;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;
        private readonly IMenuIngredientRepository _menuIngredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository,
                                 IMapper mapper,
                                 IMenuIngredientRepository menuIngredientRepository)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
            _menuIngredientRepository = menuIngredientRepository;
        }

        public async Task CreateAsync(IngredientCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            if (!await _ingredientRepository.ExistAsync(model.Name))
            {
                await _ingredientRepository.CreateAsync(_mapper.Map<Ingredient>(model));
            }
        }

        public async Task EditAsync(int? id, IngredientEditDto model)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(model);

            var ingredient = await _ingredientRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            if (!await _ingredientRepository.ExistAsync(model.Name, id))
            {
                ingredient.UpdatedDate = DateTime.Now;
                await _ingredientRepository.EditAsync(_mapper.Map(model, ingredient));
            }
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var ingredient = await _ingredientRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            await _ingredientRepository.DeleteAsync(ingredient);
        }

        public async Task<IEnumerable<IngredientDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<IngredientDto>>(await _ingredientRepository.GetAllAsync());
        }

        public async Task<IEnumerable<IngredientSelectDto>> GetAllForSelectAsync(int? excludeId = null)
        {
            var ingredientIds = _menuIngredientRepository
                .GetAllWithExpressionAsync(m => m.MenuId == excludeId).Result
                .Select(m => m.IngredientId);

            var ingredients = _ingredientRepository
                .GetAllAsync().Result
                .Where(m => !ingredientIds.Contains(m.Id))
                .OrderBy(m => m.Name);

            return _mapper.Map<IEnumerable<IngredientSelectDto>>(ingredients);
        }

        public async Task<PaginationResponse<IngredientDto>> GetPaginateAsync(int? page, int? take, string? searchText)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            IEnumerable<Ingredient> ingredients;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                ingredients = await _ingredientRepository.GetAllAsync();
            }
            else
            {
                ingredients = await _ingredientRepository.GetAllWithExpressionAsync(m => m.Name.Contains(searchText));
            }

            int totalPage = (int)Math.Ceiling((decimal)ingredients.Count() / (int)take);

            var mappedDatas = _mapper.Map<IEnumerable<IngredientDto>>(await _ingredientRepository.GetPaginateDatasAsync((int)page, (int)take, searchText));

            return new PaginationResponse<IngredientDto>(mappedDatas, totalPage, (int)page);
        }

        public async Task<IngredientDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return _mapper.Map<IngredientDto>(await _ingredientRepository.GetByIdAsync((int)id));
        }

        public async Task<bool> ExistAsync(string name, int? excludeId = null)
        {
            ArgumentNullException.ThrowIfNull(name);
            return await _ingredientRepository.ExistAsync(name, excludeId);
        }
    }
}

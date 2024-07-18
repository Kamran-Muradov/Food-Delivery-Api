using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Ingredients;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public IngredientService(IIngredientRepository ingredientRepository,
                                 IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(IngredientCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            if (await _ingredientRepository.GetByNameAsync(model.Name) is not null)
            {
                throw new BadRequestException(ResponseMessages.ExistData);
            }

            await _ingredientRepository.CreateAsync(_mapper.Map<Ingredient>(model));
        }

        public async Task EditAsync(int? id, IngredientEditDto model)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(model);

            var ingredient = await _ingredientRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            if (ingredient.Id != id && await _ingredientRepository.GetByNameAsync(model.Name) is not null)
            {
                throw new BadRequestException(ResponseMessages.ExistData);
            }

            ingredient.UpdatedDate = DateTime.Now;
            await _ingredientRepository.EditAsync(_mapper.Map(model, ingredient));
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

        public async Task<IngredientDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            return _mapper.Map<IngredientDto>(await _ingredientRepository.GetByIdAsync((int)id));
        }
    }
}

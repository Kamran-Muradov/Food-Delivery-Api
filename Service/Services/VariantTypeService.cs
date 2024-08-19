using AutoMapper;
using Domain.Entities;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Countries;
using Service.DTOs.Admin.VariantTypes;
using Service.Helpers;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class VariantTypeService : IVariantTypeService
    {
        private readonly IMapper _mapper;
        private readonly IVariantTypeRepository _variantTypeRepository;

        public VariantTypeService(IMapper mapper, 
                                  IVariantTypeRepository variantTypeRepository)
        {
            _mapper = mapper;
            _variantTypeRepository = variantTypeRepository;
        }

        public async Task CreateAsync(VariantTypeCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            if (!await _variantTypeRepository.ExistAsync(model.Name))
            {
                await _variantTypeRepository.CreateAsync(_mapper.Map<VariantType>(model));
            }
        }

        public async Task EditAsync(int? id, VariantTypeEditDto model)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(model);

            var variantType = await _variantTypeRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            if (!await _variantTypeRepository.ExistAsync(model.Name, id))
            {
                variantType.UpdatedDate = DateTime.Now;
                await _variantTypeRepository.EditAsync(_mapper.Map(model, variantType));
            }
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var variantType = await _variantTypeRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            await _variantTypeRepository.DeleteAsync(variantType);
        }

        public async Task<IEnumerable<VariantTypeSelectDto>> GetAllForSelectAsync(int? excludeId = null)
        {
            var variantTypes = await _variantTypeRepository.GetAllWithExpressionAsync(r => r.MenuVariants.All(m => m.Id != excludeId));

            return _mapper.Map<IEnumerable<VariantTypeSelectDto>>(variantTypes);
        }

        public async Task<PaginationResponse<VariantTypeDto>> GetPaginateAsync(int? page, int? take)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            var variantTypes = await _variantTypeRepository.GetAllAsync();
            int totalPage = (int)Math.Ceiling((decimal)variantTypes.Count() / (int)take);

            var mappedDatas = _mapper.Map<IEnumerable<VariantTypeDto>>(await _variantTypeRepository.GetPaginateDatasAsync((int)page, (int)take));

            return new PaginationResponse<VariantTypeDto>(mappedDatas, totalPage, (int)page);
        }

        public async Task<VariantTypeDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return _mapper.Map<VariantTypeDto>(await _variantTypeRepository.GetByIdAsync((int)id));
        }

        public async Task<bool> ExistAsync(string name, int? excludeId = null)
        {
            ArgumentNullException.ThrowIfNull(name);
            return await _variantTypeRepository.ExistAsync(name, excludeId);
        }
    }
}

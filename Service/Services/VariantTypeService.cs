using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.VariantTypes;
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

        public async Task<IEnumerable<VariantTypeSelectDto>> GetAllForSelectAsync(int? excludeId = null)
        {
            var variantTypes = await _variantTypeRepository.GetAllWithExpressionAsync(r => r.MenuVariants.All(m => m.Id != excludeId));

            return _mapper.Map<IEnumerable<VariantTypeSelectDto>>(variantTypes);
        }
    }
}

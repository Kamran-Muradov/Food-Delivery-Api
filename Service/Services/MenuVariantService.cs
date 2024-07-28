using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.MenuVariants;
using Service.Helpers;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class MenuVariantService : IMenuVariantService
    {
        private readonly IMenuVariantRepository _menuVariantRepository;
        private readonly IMapper _mapper;

        public MenuVariantService(IMenuVariantRepository menuVariantRepository,
                                  IMapper mapper)
        {
            _menuVariantRepository = menuVariantRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(MenuVariantCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);
            if (!await _menuVariantRepository.ExistAsync(model.MenuId, model.VariantTypeId, model.Option))
            {
                await _menuVariantRepository.CreateAsync(_mapper.Map<MenuVariant>(model));

            }
        }

        public async Task EditAsync(int? id, MenuVariantEditDto model)
        {
            ArgumentNullException.ThrowIfNull(id);
            ArgumentNullException.ThrowIfNull(model);

            var menuVariant = await _menuVariantRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            if (!await _menuVariantRepository.ExistAsync((int)model.MenuId, (int)model.VariantTypeId, model.Option,id))
            {
                menuVariant.UpdatedDate = DateTime.Now;
                await _menuVariantRepository.EditAsync(_mapper.Map(model, menuVariant));
            }
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var ingredient = await _menuVariantRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            await _menuVariantRepository.DeleteAsync(ingredient);
        }

        public async Task<PaginationResponse<MenuVariantDto>> GetPaginateAsync(int? page, int? take)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            var menuVariants = await _menuVariantRepository.GetAllAsync();
            int totalPage = (int)Math.Ceiling((decimal)menuVariants.Count() / (int)take);

            var mappedDatas = _mapper.Map<IEnumerable<MenuVariantDto>>(await _menuVariantRepository.GetPaginateDatasAsync((int)page, (int)take));

            return new PaginationResponse<MenuVariantDto>(mappedDatas, totalPage, (int)page);
        }

        public async Task<MenuVariantDetailDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            return _mapper.Map<MenuVariantDetailDto>(await _menuVariantRepository.GetByIdWithAllDatasAsync((int)id));
        }

        public async Task<bool> ExistAsync(int? menuId, int? variantTypeId, string option, int? excludeId = null)
        {
            ArgumentNullException.ThrowIfNull(menuId);
            ArgumentNullException.ThrowIfNull(variantTypeId);
            ArgumentNullException.ThrowIfNull(option);

            return await _menuVariantRepository.ExistAsync((int)menuId, (int)variantTypeId, option, excludeId);
        }
    }
}

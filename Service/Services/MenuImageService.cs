using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Menus;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class MenuImageService : IMenuImageService
    {
        private readonly IMenuImageRepository _menuImageRepository;
        private readonly IMapper _mapper;

        public MenuImageService(IMenuImageRepository menuImageRepository, 
                                IMapper mapper)
        {
            _menuImageRepository = menuImageRepository;
            _mapper = mapper;
        }

        public async Task<MenuImageDto> GetByMenuId(int? menuId)
        {
            ArgumentNullException.ThrowIfNull(menuId);
            return _mapper.Map<MenuImageDto>(await _menuImageRepository.GetByMenuId((int)menuId));
        }
    }
}

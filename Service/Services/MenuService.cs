using AutoMapper;
using CloudinaryDotNet.Actions;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Menus;
using Service.Helpers;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly IMenuImageRepository _menuImageRepository;
        private readonly IMenuIngredientRepository _menuIngredientRepository;

        public MenuService(IMenuRepository menuRepository,
                           IMapper mapper,
                           IPhotoService photoService,
                           IMenuImageRepository menuImageRepository,
                           IMenuIngredientRepository menuIngredientRepository)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
            _photoService = photoService;
            _menuImageRepository = menuImageRepository;
            _menuIngredientRepository = menuIngredientRepository;
        }

        public async Task CreateAsync(MenuCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            Menu menu = _mapper.Map<Menu>(model);

            ImageUploadResult uploadResult = await _photoService.AddPhoto(model.Image);

            MenuImage menuImage = new()
            {
                Url = uploadResult.SecureUrl.ToString(),
                PublicId = uploadResult.PublicId,
                MenuId = menu.Id
            };

            menu.MenuImage = menuImage;

            List<MenuIngredient> menuIngredients = model.IngredientIds.Select(ingredientId => new MenuIngredient
            {
                MenuId = menu.Id,
                IngredientId = ingredientId
            }).ToList();

            menu.MenuIngredients = menuIngredients;

            await _menuRepository.CreateAsync(menu);
        }

        public async Task EditAsync(int? id, MenuEditDto model)
        {
            ArgumentNullException.ThrowIfNull(id);
            ArgumentNullException.ThrowIfNull(model);

            var menu = await _menuRepository.GetByIdWithAllDatasAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            var removedIngredients = menu.MenuIngredients
                .Where(mc => !model.IngredientIds.Contains(mc.IngredientId));

            foreach (var menuIngredient in removedIngredients)
            {
                await _menuIngredientRepository.DeleteAsync(menuIngredient);
            }

            foreach (var ingredientId in model.IngredientIds.Where(ingredientId => menu.MenuIngredients.All(m => m.IngredientId != ingredientId)))
            {
                await _menuIngredientRepository.CreateAsync(new MenuIngredient
                {
                    MenuId = (int)id,
                    IngredientId = ingredientId
                });
            }

            if (model.Image is not null)
            {
                await _photoService.DeletePhoto(menu.MenuImage.PublicId);
                await _menuImageRepository.DeleteAsync(menu.MenuImage);

                ImageUploadResult uploadResult = await _photoService.AddPhoto(model.Image);

                MenuImage menuImage = new()
                {
                    Url = uploadResult.SecureUrl.ToString(),
                    PublicId = uploadResult.PublicId,
                    MenuId = menu.Id
                };

                menu.MenuImage = menuImage;
            }

            var map = _mapper.Map(model, menu);

            menu.UpdatedDate = DateTime.Now;
            await _menuRepository.EditAsync(menu);
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var menu = await _menuRepository.GetByIdWithAllDatasAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            await _photoService.DeletePhoto(menu.MenuImage.PublicId);

            await _menuRepository.DeleteAsync(menu);
        }

        public async Task<PaginationResponse<MenuDto>> GetPaginateAsync(int? page, int? take, string? searchText)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            IEnumerable<Menu> menus;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                menus = await _menuRepository.GetAllAsync();
            }
            else
            {
                menus = await _menuRepository.GetAllWithExpressionAsync(m => m.Name.Contains(searchText));
            }

            int totalPage = (int)Math.Ceiling((decimal)menus.Count() / (int)take);

            var mappedDatas = _mapper.Map<IEnumerable<MenuDto>>(await _menuRepository.GetPaginateDatasAsync((int)page, (int)take, searchText));

            return new PaginationResponse<MenuDto>(mappedDatas, totalPage, (int)page);
        }

        public async Task<IEnumerable<MenuSelectDto>> GetAllForSelectAsync(int? excludeId = null)
        {
            var menus = await _menuRepository.GetAllWithExpressionAsync(r => r.MenuVariants.All(m => m.Id != excludeId));

            return _mapper.Map<IEnumerable<MenuSelectDto>>(menus);
        }

        public async Task<MenuDetailDto> GetByIdDetailAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            return _mapper.Map<MenuDetailDto>(await _menuRepository.GetByIdWithAllDatasAsync((int)id));
        }

        public async Task<DTOs.UI.Menus.MenuDetailDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            return _mapper.Map<DTOs.UI.Menus.MenuDetailDto>(await _menuRepository.GetByIdWithAllDatasAsync((int)id));
        }

        public async Task<IEnumerable<MenuDto>> SearchByNameAndCategory(string searchText)
        {
            ArgumentNullException.ThrowIfNull(searchText);
            return _mapper.Map<IEnumerable<MenuDto>>(await _menuRepository.SearchByNameAndCategory(searchText));
        }
    }
}

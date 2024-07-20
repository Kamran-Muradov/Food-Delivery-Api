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
        private readonly IRestaurantCategoryRepository _restaurantCategoryRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMenuCategoryRepository _menuCategoryRepository;

        public MenuService(IMenuRepository menuRepository,
                           IMapper mapper,
                           IPhotoService photoService,
                           IMenuImageRepository menuImageRepository,
                           IRestaurantCategoryRepository restaurantCategoryRepository,
                           IRestaurantRepository restaurantRepository,
                           IMenuCategoryRepository menuCategoryRepository)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
            _photoService = photoService;
            _menuImageRepository = menuImageRepository;
            _restaurantCategoryRepository = restaurantCategoryRepository;
            _restaurantRepository = restaurantRepository;
            _menuCategoryRepository = menuCategoryRepository;
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

            List<MenuCategory> menuCategories = new();

            foreach (var categoryId in model.CategoryIds)
            {
                menuCategories.Add(new MenuCategory
                {
                    MenuId = menu.Id,
                    CategoryId = categoryId
                });

                if (await _restaurantCategoryRepository.GetByIdAsync(model.RestaurantId, categoryId) is null)
                {
                    await _restaurantCategoryRepository.CreateAsync(new RestaurantCategory
                    {
                        RestaurantId = model.RestaurantId,
                        CategoryId = categoryId
                    });
                }
            }

            menu.MenuCategories = menuCategories;

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

            var menu = await _menuRepository.GetByIdWithImagesAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

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

            menu.UpdatedDate = DateTime.Now;
            await _menuRepository.EditAsync(_mapper.Map(model, menu));
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var menu = await _menuRepository.GetByIdWithImagesAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            var restaurant = await _restaurantRepository.GetByIdWithMenusAsync(menu.RestaurantId);

            foreach (var menuCategory in menu.MenuCategories)
            {
                var test = restaurant.Menus.FirstOrDefault(m => m.MenuCategories.Any(mc => mc.CategoryId != menuCategory.CategoryId));

                if (!restaurant.Menus.Any(m => m.MenuCategories.Any(mc => mc.CategoryId == menuCategory.CategoryId)))
                {
                    var restaurantCategory = await _restaurantCategoryRepository.GetByIdAsync(menuCategory.CategoryId);

                    await _restaurantCategoryRepository.DeleteAsync(restaurantCategory);
                }
            }

            await _photoService.DeletePhoto(menu.MenuImage.PublicId);

            await _menuRepository.DeleteAsync(menu);
        }

        public async Task<PaginationResponse<MenuDto>> GetPaginateAsync(int? page, int? take)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            var restaurants = await _menuRepository.GetAllAsync();
            int totalPage = (int)Math.Ceiling((decimal)restaurants.Count() / (int)take);

            var mappedDatas = _mapper.Map<IEnumerable<MenuDto>>(await _menuRepository.GetPaginateDatasAsync((int)page, (int)take));

            return new PaginationResponse<MenuDto>(mappedDatas, totalPage, (int)page);
        }

        public async Task<MenuDetailDto> GetByIdDetailAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            return _mapper.Map<MenuDetailDto>(await _menuRepository.GetByIdWithAllDatasAsync((int)id));
        }
    }
}

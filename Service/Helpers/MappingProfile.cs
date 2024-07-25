using AutoMapper;
using Domain.Entities;
using Service.DTOs.Account;
using Service.DTOs.Admin.Categories;
using Service.DTOs.Admin.Ingredients;
using Service.DTOs.Admin.Menus;
using Service.DTOs.Admin.Restaurants;
using CategoryDto = Service.DTOs.Admin.Categories.CategoryDto;

namespace Service.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Ingredient
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientCreateDto, Ingredient>();
            CreateMap<IngredientEditDto, Ingredient>();

            //Category
            CreateMap<Category, CategoryDto>()
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.CategoryImage.Url))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")))
                .ForMember(d => d.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate != null ? s.UpdatedDate.Value.ToString("MM/dd/yyyy") : "N/A"));
            CreateMap<Category, DTOs.UI.Categories.CategoryDto>()
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.CategoryImage.Url));
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryEditDto, Category>();
            CreateMap<CategoryImage, CategoryImageDto>();

            //Restaurant
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(d => d.MainImage, opt => opt.MapFrom(s => s.RestaurantImages.FirstOrDefault(m => m.IsMain).Url));
            CreateMap<Restaurant, DTOs.UI.Restaurants.RestaurantDto>()
                .ForMember(d => d.MainImage, opt => opt.MapFrom(s => s.RestaurantImages.FirstOrDefault(m => m.IsMain).Url));
            CreateMap<RestaurantImage, RestaurantImageDto>();
            CreateMap<Restaurant, RestaurantDetailDto>()
                .ForMember(d => d.Categories, opt => opt.MapFrom(s => s.RestaurantCategories.Select(m => m.Category.Name)))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")))
                .ForMember(d => d.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate != null ? s.UpdatedDate.Value.ToString("MM/dd/yyyy") : "N/A"));
            CreateMap<RestaurantCreateDto, Restaurant>();
            CreateMap<RestaurantEditDto, Restaurant>();

            //Menu
            CreateMap<Menu, MenuDto>()
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.MenuImage.Url));
            CreateMap<Menu, MenuDetailDto>()
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.MenuImage.Url))
                .ForMember(d => d.Restaurant, opt => opt.MapFrom(s => s.Restaurant.Name))
                .ForMember(d => d.Ingredients, opt => opt.MapFrom(s => s.MenuIngredients.Select(m => m.Ingredient.Name)))
                .ForMember(d => d.Categories, opt => opt.MapFrom(s => s.MenuCategories.Select(m => m.Category.Name)));
            CreateMap<MenuCreateDto, Menu>();
            CreateMap<MenuEditDto, Menu>();

            //Account
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, UserDto>();
        }
    }
}

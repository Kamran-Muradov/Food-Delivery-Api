using AutoMapper;
using Domain.Entities;
using Service.DTOs.Admin.Categories;
using Service.DTOs.Admin.Ingredients;
using Service.DTOs.Admin.Menus;
using Service.DTOs.Admin.Restaurants;

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
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryEditDto, Category>();

            //Restaurant
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<RestaurantImage, RestaurantImageDto>();
            CreateMap<Restaurant, RestaurantDetailDto>()
                .ForMember(d => d.Categories, opt => opt.MapFrom(s => s.RestaurantCategories.Select(m => m.Category.Name)));
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
        }
    }
}

using AutoMapper;
using Domain.Entities;
using Service.DTOs.Admin.Categories;
using Service.DTOs.Admin.Ingredients;
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
                //.ForMember(d => d.Images, opt => opt.MapFrom(s => s.RestaurantImages.Select(m => m.Url)));
            CreateMap<RestaurantCreateDto, Restaurant>();
            CreateMap<RestaurantEditDto, Restaurant>();
        }
    }
}

using AutoMapper;
using Domain.Entities;
using Service.DTOs.Account;
using Service.DTOs.Admin.Categories;
using Service.DTOs.Admin.Ingredients;
using Service.DTOs.Admin.Menus;
using Service.DTOs.Admin.MenuVariants;
using Service.DTOs.Admin.Restaurants;
using Service.DTOs.Admin.VariantTypes;
using CategoryDto = Service.DTOs.Admin.Categories.CategoryDto;

namespace Service.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Ingredient
            CreateMap<Ingredient, IngredientSelectDto>();
            CreateMap<Ingredient, IngredientDto>()
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")))
                .ForMember(d => d.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate != null ? s.UpdatedDate.Value.ToString("MM/dd/yyyy") : "N/A"));
            CreateMap<IngredientCreateDto, Ingredient>();
            CreateMap<IngredientEditDto, Ingredient>();

            //Category
            CreateMap<Category, CategorySelectDto>();
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
            CreateMap<Restaurant, RestaurantSelectDto>();
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
            CreateMap<Menu, MenuSelectDto>();
            CreateMap<Menu, MenuDto>()
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.MenuImage.Url))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")))
                .ForMember(d => d.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate != null ? s.UpdatedDate.Value.ToString("MM/dd/yyyy") : "N/A"));
            CreateMap<Menu, MenuDetailDto>()
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.MenuImage.Url))
                .ForMember(d => d.Restaurant, opt => opt.MapFrom(s => s.Restaurant.Name))
                .ForMember(d => d.Ingredients, opt => opt.MapFrom(s => s.MenuIngredients.Select(m => m.Ingredient.Name)))
                .ForMember(d => d.Categories, opt => opt.MapFrom(s => s.MenuCategories.Select(m => m.Category.Name)))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")))
                .ForMember(d => d.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate != null ? s.UpdatedDate.Value.ToString("MM/dd/yyyy") : "N/A"));
            CreateMap<MenuCreateDto, Menu>();
            CreateMap<MenuEditDto, Menu>()
                .ForMember(d => d.RestaurantId, opt => opt.Condition(s => s.RestaurantId != null));
            CreateMap<MenuImage, MenuImageDto>();

            //MenuVariant
            CreateMap<MenuVariant, MenuVariantDto>()
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")))
                .ForMember(d => d.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate != null ? s.UpdatedDate.Value.ToString("MM/dd/yyyy") : "N/A"));
            CreateMap<MenuVariant, MenuVariantDetailDto>()
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")))
                .ForMember(d => d.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate != null ? s.UpdatedDate.Value.ToString("MM/dd/yyyy") : "N/A"))
                .ForMember(d => d.Menu, opt => opt.MapFrom(s => s.Menu.Name))
                .ForMember(d => d.VariantType, opt => opt.MapFrom(s => s.VariantType.Name));
            CreateMap<MenuVariantCreateDto, MenuVariant>();
            CreateMap<MenuVariantEditDto, MenuVariant>()
                .ForMember(d => d.MenuId, opt => opt.Condition(s => s.MenuId != null))
                .ForMember(d => d.VariantTypeId, opt => opt.Condition(s => s.VariantTypeId != null));

            //Account
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, UserDto>();

            //VariantType
            CreateMap<VariantType, VariantTypeSelectDto>();
        }
    }
}

using AutoMapper;
using Domain.Entities;
using Service.DTOs.Admin.Brands;
using Service.DTOs.Admin.Categories;
using Service.DTOs.Admin.Contacts;
using Service.DTOs.Admin.Ingredients;
using Service.DTOs.Admin.Menus;
using Service.DTOs.Admin.MenuVariants;
using Service.DTOs.Admin.Restaurants;
using Service.DTOs.Admin.Settings;
using Service.DTOs.Admin.Sliders;
using Service.DTOs.Admin.SocialMedias;
using Service.DTOs.Admin.Tags;
using Service.DTOs.Admin.VariantTypes;
using Service.DTOs.UI.Account;
using Service.DTOs.UI.BasketItems;
using Service.DTOs.UI.Checkouts;
using Service.DTOs.UI.Contacts;
using Service.DTOs.UI.Reviews;
using CategoryDto = Service.DTOs.Admin.Categories.CategoryDto;
using CheckoutDto = Service.DTOs.UI.Checkouts.CheckoutDto;
using RestaurantDetailDto = Service.DTOs.Admin.Restaurants.RestaurantDetailDto;
using RestaurantDto = Service.DTOs.Admin.Restaurants.RestaurantDto;

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

            //Setting
            CreateMap<Setting, SettingDto>()
                .ForMember(d => d.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate != null ? s.UpdatedDate.Value.ToString("MM/dd/yyyy") : "N/A"));
            CreateMap<SettingEditDto, Setting>();

            //SocialMedia
            CreateMap<SocialMedia, SocialMediaDto>()
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")))
                .ForMember(d => d.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate != null ? s.UpdatedDate.Value.ToString("MM/dd/yyyy") : "N/A"));
            CreateMap<SocialMedia, DTOs.UI.SocialMedias.SocialMediaDto>();
            CreateMap<SocialMediaCreateDto, SocialMedia>();
            CreateMap<SocialMediaEditDto, SocialMedia>();

            //Brand
            CreateMap<Brand, BrandSelectDto>();
            CreateMap<Brand, BrandDto>()
                .ForMember(d => d.Logo, opt => opt.MapFrom(s => s.BrandLogo.Url))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")))
                .ForMember(d => d.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate != null ? s.UpdatedDate.Value.ToString("MM/dd/yyyy") : "N/A"));
            CreateMap<Brand, DTOs.UI.Brands.BrandDto>()
                .ForMember(d => d.Logo, opt => opt.MapFrom(s => s.BrandLogo.Url));
            CreateMap<BrandCreateDto, Brand>();
            CreateMap<BrandEditDto, Brand>();
            CreateMap<BrandLogo, BrandLogoDto>();

            //Tag
            CreateMap<Tag, TagSelectDto>();
            CreateMap<Tag, TagDto>()
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.TagImage.Url))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")))
                .ForMember(d => d.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate != null ? s.UpdatedDate.Value.ToString("MM/dd/yyyy") : "N/A"));
            CreateMap<Tag, DTOs.UI.Tags.TagDto>()
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.TagImage.Url));
            CreateMap<TagCreateDto, Tag>();
            CreateMap<TagEditDto, Tag>();
            CreateMap<TagImage, TagImageDto>();

            CreateMap<Contact, ContactDto>();
            CreateMap<Contact, ContactDetailDto>()
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")));
            CreateMap<ContactCreateDto, Contact>();

            //Restaurant
            CreateMap<Restaurant, RestaurantSelectDto>();
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(d => d.MainImage, opt => opt.MapFrom(s => s.RestaurantImages.FirstOrDefault(m => m.IsMain).Url));
            CreateMap<Restaurant, DTOs.UI.Restaurants.RestaurantDto>()
                .ForMember(d => d.Tags, opt => opt.MapFrom(s => s.RestaurantTags.Select(m => m.Tag)));
            CreateMap<RestaurantImage, RestaurantImageDto>();
            CreateMap<Restaurant, RestaurantDetailDto>()
                .ForMember(d => d.Tags, opt => opt.MapFrom(s => s.RestaurantTags.Select(m => m.Tag.Name)))
                .ForMember(d => d.Brand, opt => opt.MapFrom(s => s.Brand != null ? s.Brand.Name : "N/A"))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")))
                .ForMember(d => d.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate != null ? s.UpdatedDate.Value.ToString("MM/dd/yyyy") : "N/A"));
            CreateMap<RestaurantCreateDto, Restaurant>();
            CreateMap<RestaurantEditDto, Restaurant>();
            CreateMap<RestaurantTag, DTOs.UI.Tags.TagDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Tag.Name))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Tag.Id))
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.Tag.TagImage.Url));
            CreateMap<Restaurant, DTOs.UI.Restaurants.RestaurantDetailDto>();

            //Menu
            CreateMap<Menu, MenuSelectDto>();
            CreateMap<Menu, MenuDto>()
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.MenuImage.Url))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")))
                .ForMember(d => d.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate != null ? s.UpdatedDate.Value.ToString("MM/dd/yyyy") : "N/A"));
            CreateMap<Menu, DTOs.UI.Menus.MenuDto>()
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.MenuImage.Url))
                .ForMember(d => d.Ingredients, opt => opt.MapFrom(s => s.MenuIngredients.Select(m => m.Ingredient.Name)));
            CreateMap<Menu, MenuDetailDto>()
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.MenuImage.Url))
                .ForMember(d => d.Restaurant, opt => opt.MapFrom(s => s.Restaurant.Name))
                .ForMember(d => d.Ingredients, opt => opt.MapFrom(s => s.MenuIngredients.Select(m => m.Ingredient.Name)))
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category.Name))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")))
                .ForMember(d => d.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate != null ? s.UpdatedDate.Value.ToString("MM/dd/yyyy") : "N/A"));
            CreateMap<MenuCreateDto, Menu>();
            CreateMap<MenuEditDto, Menu>()
                .ForMember(d => d.RestaurantId, opt => opt.Condition(s => s.RestaurantId != null));
            CreateMap<MenuImage, MenuImageDto>();
            CreateMap<Menu, DTOs.UI.Menus.MenuDetailDto>()
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.MenuImage.Url))
                .ForMember(d => d.Restaurant, opt => opt.MapFrom(s => s.Restaurant.Name))
                .ForMember(d => d.Ingredients, opt => opt.MapFrom(s => s.MenuIngredients.Select(m => m.Ingredient.Name)))
                .ForMember(d => d.MenuVariants,
                    opt => opt.MapFrom(s => s.MenuVariants.GroupBy(mv => mv.VariantType.Name).ToDictionary(g => g.Key, g => g.AsEnumerable())));

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
            CreateMap<MenuVariant, DTOs.UI.MenuVariants.MenuVariantDto>()
                .ForMember(d => d.VariantType, opt => opt.MapFrom(s => s.VariantType.Name));

            //Account
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, UserDto>()
                .ForMember(d => d.ProfilePicture, opt => opt.MapFrom(s => s.UserImage.Url));
            CreateMap<UserImage, UserImageDto>();

            //VariantType
            CreateMap<VariantType, VariantTypeSelectDto>();

            //BasketItem
            CreateMap<BasketItem, BasketItemDto>()
                .ForMember(d => d.BasketVariants,
                    opt => opt.MapFrom(s => s.BasketVariants.GroupBy(bv => bv.Type).ToDictionary(g => g.Key, g => g.Select(m => m.Option).ToList())))
                .ForMember(d => d.Restaurant, opt => opt.MapFrom(s => s.Menu.Restaurant.Name))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Menu.Name))
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.Menu.MenuImage.Url));
            CreateMap<BasketItemCreateDto, BasketItem>()
                .ForMember(d => d.BasketVariants, opt => opt.Ignore());
            CreateMap<BasketCountDto, BasketItem>();

            //Checkout
            CreateMap<Checkout, CheckoutDto>()
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")))
                .ForMember(d => d.Restaurant, opt => opt.MapFrom(s => s.Restaurant.Name));
            CreateMap<Checkout, DTOs.Admin.Checkouts.CheckoutDto>()
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.User.UserName));
            CreateMap<CheckoutCreateDto, Checkout>();

            //User
            CreateMap<UserEditDto, AppUser>();

            //Slider
            CreateMap<Slider, SliderDto>()
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.SliderImage.Url))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")))
                .ForMember(d => d.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate != null ? s.UpdatedDate.Value.ToString("MM/dd/yyyy") : "N/A"));
            CreateMap<Slider, SliderDetailDto>()
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.SliderImage.Url))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM/dd/yyyy")))
                .ForMember(d => d.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate != null ? s.UpdatedDate.Value.ToString("MM/dd/yyyy") : "N/A"));
            CreateMap<SliderCreateDto, Slider>();
            CreateMap<SliderEditDto, Slider>();
            CreateMap<SliderImage, SliderImageDto>();
            CreateMap<Slider, DTOs.UI.Sliders.SliderDto>()
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.SliderImage.Url));

            //Review
            CreateMap<ReviewCreateDto, Review>();
            CreateMap<Review, ReviewDto>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.Checkout.User.UserName))
                .ForMember(d => d.UserImage, opt => opt.MapFrom(s => s.Checkout.User.UserImage.Url))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MMM dd, yyyy")));
        }
    }
}

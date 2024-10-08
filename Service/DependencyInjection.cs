﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Service.DTOs.Account;
using Service.DTOs.Admin.Abouts;
using Service.DTOs.Admin.Brands;
using Service.DTOs.Admin.Categories;
using Service.DTOs.Admin.Cities;
using Service.DTOs.Admin.Countries;
using Service.DTOs.Admin.Ingredients;
using Service.DTOs.Admin.Menus;
using Service.DTOs.Admin.MenuVariants;
using Service.DTOs.Admin.PromoCodes;
using Service.DTOs.Admin.Restaurants;
using Service.DTOs.Admin.Settings;
using Service.DTOs.Admin.Sliders;
using Service.DTOs.Admin.SocialMedias;
using Service.DTOs.Admin.Tags;
using Service.DTOs.Admin.VariantTypes;
using Service.DTOs.UI.BasketItems;
using Service.DTOs.UI.Checkouts;
using Service.DTOs.UI.Contacts;
using Service.DTOs.UI.Favourites;
using Service.DTOs.UI.Reviews;
using Service.Services;
using Service.Services.Interfaces;

namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });

            services.AddScoped<IValidator<IngredientCreateDto>, IngredientCreateDtoValidator>();
            services.AddScoped<IValidator<IngredientEditDto>, IngredientEditDtoValidator>();
            services.AddScoped<IIngredientService, IngredientService>();

            services.AddScoped<IValidator<FavouriteCreateDto>, FavouriteCreateDtoValidator>();
            services.AddScoped<IFavouriteService, FavouriteService>();

            services.AddScoped<IValidator<CountryCreateDto>, CountryCreateDtoValidator>();
            services.AddScoped<IValidator<CountryEditDto>, CountryEditDtoValidator>();
            services.AddScoped<ICountryService, CountryService>();

            services.AddScoped<IValidator<CityCreateDto>, CityCreateDtoValidator>();
            services.AddScoped<IValidator<CityEditDto>, CityEditDtoValidator>();
            services.AddScoped<ICityService, CityService>();

            services.AddScoped<IValidator<CategoryCreateDto>, CategoryCreateDtoValidator>();
            services.AddScoped<IValidator<CategoryEditDto>, CategoryEditDtoValidator>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryImageService, CategoryImageService>();

            services.AddScoped<IValidator<SocialMediaCreateDto>, SocialMediaCreateDtoValidator>();
            services.AddScoped<IValidator<SocialMediaEditDto>, SocialMediaEditDtoValidator>();
            services.AddScoped<ISocialMediaService, SocialMediaService>();

            services.AddScoped<IValidator<SettingEditDto>, SettingEditDtoValidator>();
            services.AddScoped<ISettingService, SettingService>();

            services.AddScoped<IValidator<BrandCreateDto>, BrandCreateDtoValidator>();
            services.AddScoped<IValidator<BrandEditDto>, BrandEditDtoValidator>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IBrandLogoService, BrandLogoService>();

            services.AddScoped<IValidator<ContactCreateDto>, ContactCreateDtoValidator>();
            services.AddScoped<IContactService, ContactService>();

            services.AddScoped<IValidator<TagCreateDto>, TagCreateDtoValidator>();
            services.AddScoped<IValidator<TagEditDto>, TagEditDtoValidator>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITagImageService, TagImageService>();

            services.AddScoped<IValidator<ReviewCreateDto>, ReviewCreateDtoValidator>();
            services.AddScoped<IReviewService, ReviewService>();

            services.AddScoped<IPhotoService, PhotoService>();

            services.AddScoped<IValidator<RestaurantCreateDto>, RestaurantCreateDtoValidator>();
            services.AddScoped<IValidator<RestaurantEditDto>, RestaurantEditDtoValidator>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IRestaurantImageService, RestaurantImageService>();

            services.AddScoped<IValidator<MenuCreateDto>, MenuCreateDtoValidator>();
            services.AddScoped<IValidator<MenuEditDto>, MenuEditDtoValidator>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IMenuImageService, MenuImageService>();

            services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();
            services.AddScoped<IValidator<RegisterDto>, RegisterDtoValidator>();
            services.AddScoped<IValidator<ForgotPasswordDto>, ForgotPasswordDtoValidator>();
            services.AddScoped<IValidator<PasswordResetDto>, PasswordResetDtoValidator>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IValidator<MenuVariantCreateDto>, MenuVariantCreateDtoValidator>();
            services.AddScoped<IValidator<MenuVariantEditDto>, MenuVariantEditDtoValidator>();
            services.AddScoped<IMenuVariantService, MenuVariantService>();
                
            services.AddScoped<IValidator<VariantTypeCreateDto>, VariantTypeCreateDtoValidator>();
            services.AddScoped<IValidator<VariantTypeEditDto>, VariantTypeEditDtoValidator>();
            services.AddScoped<IVariantTypeService, VariantTypeService>();

            services.AddScoped<IValidator<BasketItemCreateDto>, BasketItemCreateDtoValidator>();
            services.AddScoped<IValidator<BasketCountDto>, BasketItemEditDtoValidator>();
            services.AddScoped<IBasketItemService, BasketItemService>();

            services.AddScoped<IValidator<CheckoutCreateDto>, CheckoutCreateDtoValidator>();
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<IPaymentService, PaymentService>();

            services.AddScoped<IValidator<SliderCreateDto>, SliderCreateDtoValidator>();
            services.AddScoped<IValidator<SliderEditDto>, SliderEditDtoValidator>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<ISliderImageService, SliderImageService>();

            services.AddScoped<IValidator<AboutCreateDto>, AboutCreateDtoValidator>();
            services.AddScoped<IValidator<AboutEditDto>, AboutEditDtoValidator>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IAboutImageService, AboutImageService>();

            services.AddScoped<IValidator<PromoCodeCreateDto>, PromoCodeCreateDtoValidator>();
            services.AddScoped<IValidator<PromoCodeEditDto>, PromoCodeEditDtoValidator>();
            services.AddScoped<IPromoCodeService, PromoCodeService>();

            return services;
        }
    }
}

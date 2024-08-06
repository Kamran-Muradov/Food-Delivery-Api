using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Service.DTOs.Account;
using Service.DTOs.Admin.Categories;
using Service.DTOs.Admin.Ingredients;
using Service.DTOs.Admin.Menus;
using Service.DTOs.Admin.MenuVariants;
using Service.DTOs.Admin.Restaurants;
using Service.DTOs.Admin.Tags;
using Service.DTOs.UI.BasketItems;
using Service.DTOs.UI.Checkouts;
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

            services.AddScoped<IValidator<CategoryCreateDto>, CategoryCreateDtoValidator>();
            services.AddScoped<IValidator<CategoryEditDto>, CategoryEditDtoValidator>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryImageService, CategoryImageService>();

            services.AddScoped<IValidator<TagCreateDto>, TagCreateDtoValidator>();
            services.AddScoped<IValidator<TagEditDto>, TagEditDtoValidator>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITagImageService, TagImageService>();

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
            services.AddScoped<IVariantTypeService, VariantTypeService>();

            services.AddScoped<IValidator<BasketItemCreateDto>, BasketItemCreateDtoValidator>();
            services.AddScoped<IValidator<BasketCountDto>, BasketItemEditDtoValidator>();
            services.AddScoped<IBasketItemService, BasketItemService>();

            services.AddScoped<IValidator<CheckoutCreateDto>, CheckoutCreateDtoValidator>();
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }
    }
}

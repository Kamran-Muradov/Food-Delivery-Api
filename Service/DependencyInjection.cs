using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Service.DTOs.Admin.Categories;
using Service.DTOs.Admin.Ingredients;
using Service.DTOs.Admin.Menus;
using Service.DTOs.Admin.Restaurants;
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

            services.AddScoped<IPhotoService, PhotoService>();

            services.AddScoped<IValidator<RestaurantCreateDto>, RestaurantCreateDtoValidator>();
            services.AddScoped<IValidator<RestaurantEditDto>, RestaurantEditDtoValidator>();
            services.AddScoped<IRestaurantService, RestaurantService>();

            services.AddScoped<IValidator<MenuCreateDto>, MenuCreateDtoValidator>();
            services.AddScoped<IValidator<MenuEditDto>, MenuEditDtoValidator>();
            services.AddScoped<IMenuService, MenuService>();


            return services;
        }
    }
}

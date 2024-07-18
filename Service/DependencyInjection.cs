using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Service.DTOs.Admin.Ingredients;
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

            return services;
        }
    }
}

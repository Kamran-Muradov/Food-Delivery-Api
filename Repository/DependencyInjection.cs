using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories.Interfaces;
using Repository.Repositories;

namespace Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IRestaurantImageRepository, RestaurantImageRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuImageRepository, MenuImageRepository>();
            services.AddScoped<IRestaurantCategoryRepository, RestaurantCategoryRepository>();
            services.AddScoped<IMenuCategoryRepository, MenuCategoryRepository>();
            services.AddScoped<ICategoryImageRepository, CategoryImageRepository>();
            services.AddScoped<IMenuIngredientRepository, MenuIngredientRepository>();
            services.AddScoped<IMenuVariantRepository, MenuVariantRepository>();
            services.AddScoped<IVariantTypeRepository, VariantTypeRepository>();

            return services;
        }
    }
}

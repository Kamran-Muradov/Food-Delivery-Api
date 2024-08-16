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
            services.AddScoped<IRestaurantTagRepository, RestaurantTagRepository>();
            services.AddScoped<ICategoryImageRepository, CategoryImageRepository>();
            services.AddScoped<IMenuIngredientRepository, MenuIngredientRepository>();
            services.AddScoped<IMenuVariantRepository, MenuVariantRepository>();
            services.AddScoped<IVariantTypeRepository, VariantTypeRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagImageRepository, TagImageRepository>();
            services.AddScoped<IBasketItemRepository, BasketItemRepository>();
            services.AddScoped<ICheckoutRepository, CheckoutRepository>();
            services.AddScoped<IBasketVariantRepository, BasketVariantRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<ISliderImageRepository, SliderImageRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IBrandLogoRepository, BrandLogoRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IUserImageRepository, UserImageRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IAboutImageRepository, AboutImageRepository>();

            return services;
        }
    }
}

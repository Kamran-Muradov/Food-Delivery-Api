using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantCategory> RestaurantCategories { get; set; }
        public DbSet<RestaurantImage> RestaurantImages { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuIngredient> MenuIngredients { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<MenuImage> MenuImages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<CategoryImage> CategoryImages { get; set; }
        public DbSet<MenuVariant> MenuVariants { get; set; }
        public DbSet<VariantType> VariantTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntity).Assembly);

            modelBuilder.Entity<VariantType>().HasData(
                new VariantType
                {
                    Id = 1,
                    Name = "Size",
                    CreatedDate = DateTime.Now
                },
                new VariantType
                {
                    Id = 2,
                    Name = "Sauce",
                    CreatedDate = DateTime.Now
                },
                new VariantType
                {
                    Id = 3,
                    Name = "Drink",
                    CreatedDate = DateTime.Now
                },
                new VariantType
                {
                    Id = 4,
                    Name = "Crust",
                    CreatedDate = DateTime.Now
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

using System.Security.Claims;
using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Repository.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AppDbContext(IHttpContextAccessor httpContextAccessor,
                            DbContextOptions<AppDbContext> options) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantTag> RestaurantTags { get; set; }
        public DbSet<RestaurantImage> RestaurantImages { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuIngredient> MenuIngredients { get; set; }
        public DbSet<MenuImage> MenuImages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<CategoryImage> CategoryImages { get; set; }
        public DbSet<MenuVariant> MenuVariants { get; set; }
        public DbSet<VariantType> VariantTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagImage> TagImages { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<BasketVariant> BasketVariants { get; set; }
        public DbSet<CheckoutMenu> CheckoutMenus { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandLogo> BrandLogos { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserImage> UserImages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutImage> AboutImages { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<UserPromoCode> UserPromoCodes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Favourite> Favourites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntity).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            SetAuditFields();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetAuditFields()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            var currentUserName = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.CreatedBy = currentUserName;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.UtcNow;
                        entry.Entity.UpdatedBy = currentUserName;
                        break;
                }
            }
        }
    }
}

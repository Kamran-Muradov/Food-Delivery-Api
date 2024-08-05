using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Domain.Configurations
{
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder
                .HasOne<AppUser>(m => m.User)
                .WithMany(appUser => appUser.BasketItems)
                .HasForeignKey(m => m.UserId);
        }
    }
}

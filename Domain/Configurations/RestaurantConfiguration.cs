using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.DeliveryFee)
                .IsRequired();

            builder.Property(m => m.IsActive)
                .IsRequired();

            builder.Property(m => m.MinDeliveryTime)
                .IsRequired();

            builder.Property(m => m.MinimumOrder)
                .IsRequired();

            builder.Property(m => m.Phone)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Address)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Rating)
                .IsRequired();
        }
    }
}

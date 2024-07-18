using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class RestaurantImageConfig : IEntityTypeConfiguration<RestaurantImage>
    {
        public void Configure(EntityTypeBuilder<RestaurantImage> builder)
        {
            builder.Property(m => m.PublicId)
                .IsRequired();

            builder.Property(m => m.RestaurantId)
                .IsRequired();

            builder.Property(m => m.Url)
                .IsRequired();
        }
    }
}

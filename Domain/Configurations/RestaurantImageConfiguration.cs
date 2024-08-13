using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class RestaurantImageConfiguration : IEntityTypeConfiguration<RestaurantImage>
    {
        public void Configure(EntityTypeBuilder<RestaurantImage> builder)
        {
            builder.Property(m => m.PublicId)
                .IsRequired();

            builder.Property(m => m.RestaurantId)
                .IsRequired();

            builder.Property(m => m.Url)
                .IsRequired();

            builder.Ignore(r => r.CreatedDate);
            builder.Ignore(r => r.UpdatedDate);
        }
    }
}

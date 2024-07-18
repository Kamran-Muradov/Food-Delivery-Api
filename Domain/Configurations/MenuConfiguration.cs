using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class MenuConfiguration:IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(m => m.Image)
                .IsRequired();

            builder.Property(m => m.Price)
                .IsRequired();

            builder.Property(m => m.RestaurantId)
                .IsRequired();
        }
    }
}

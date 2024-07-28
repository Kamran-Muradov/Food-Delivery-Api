using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class MenuVariantConfiguration : IEntityTypeConfiguration<MenuVariant>
    {
        public void Configure(EntityTypeBuilder<MenuVariant> builder)
        {
            builder.Property(m => m.Option)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class BrandLogoConfiguration : IEntityTypeConfiguration<BrandLogo>
    {
        public void Configure(EntityTypeBuilder<BrandLogo> builder)
        {
            builder.Property(bl => bl.CreatedDate);
            builder.Property(bl => bl.UpdatedDate);
        }
    }
}

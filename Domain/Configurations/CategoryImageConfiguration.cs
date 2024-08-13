using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class CategoryImageConfiguration : IEntityTypeConfiguration<CategoryImage>
    {
        public void Configure(EntityTypeBuilder<CategoryImage> builder)
        {
            builder.Property(ci => ci.CreatedDate);
            builder.Property(ci => ci.UpdatedDate);
        }
    }
}

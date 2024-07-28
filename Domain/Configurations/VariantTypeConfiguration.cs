using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class VariantTypeConfiguration:IEntityTypeConfiguration<VariantType>
    {
        public void Configure(EntityTypeBuilder<VariantType> builder)
        {
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

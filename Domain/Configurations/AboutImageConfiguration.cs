using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class AboutImageConfiguration : IEntityTypeConfiguration<AboutImage>
    {
        public void Configure(EntityTypeBuilder<AboutImage> builder)
        {
            builder
                .HasOne(ai => ai.About)
                .WithOne(a => a.AboutImage)
                .HasForeignKey<AboutImage>(ai => ai.AboutId);

            builder
                .Ignore(ai => ai.CreatedDate)
                .Ignore(ai => ai.CreatedBy)
                .Ignore(ai => ai.UpdatedDate)
                .Ignore(ai => ai.UpdatedBy);
        }
    }
}

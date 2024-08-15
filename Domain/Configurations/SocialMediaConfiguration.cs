using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.Property(sm => sm.Platform)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(sm=>sm.Url)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}

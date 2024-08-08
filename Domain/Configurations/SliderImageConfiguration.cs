using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class SliderImageConfiguration : IEntityTypeConfiguration<SliderImage>
    {
        public void Configure(EntityTypeBuilder<SliderImage> builder)
        {
            builder.Ignore(si => si.CreatedDate);
            builder.Ignore(si => si.UpdatedDate);
        }
    }
}

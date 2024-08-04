using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class RestaurantCategoryConfiguration : IEntityTypeConfiguration<RestaurantTag>
    {
        public void Configure(EntityTypeBuilder<RestaurantTag> builder)
        {
            builder.Ignore(m => m.Id);
            builder.Ignore(m => m.UpdatedDate);
            builder.HasKey(m => new { m.TagId, m.RestaurantId });
        }
    }
}

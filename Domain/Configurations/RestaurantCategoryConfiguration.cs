using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class RestaurantCategoryConfiguration : IEntityTypeConfiguration<RestaurantCategory>
    {
        public void Configure(EntityTypeBuilder<RestaurantCategory> builder)
        {
            builder.Ignore(m => m.Id);
            builder.Ignore(m => m.UpdatedDate);
            builder.HasKey(m => new { m.CategoryId, m.RestaurantId });
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class MenuCategoryConfiguration : IEntityTypeConfiguration<MenuCategory>
    {
        public void Configure(EntityTypeBuilder<MenuCategory> builder)
        {
            builder.Ignore(m => m.Id);
            builder.Ignore(m => m.UpdatedDate);
            builder.HasKey(m => new { m.CategoryId, m.MenuId });
        }
    }
}

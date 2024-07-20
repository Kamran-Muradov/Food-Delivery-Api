using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class MenuIngredientConfiguration : IEntityTypeConfiguration<MenuIngredient>
    {
        public void Configure(EntityTypeBuilder<MenuIngredient> builder)
        {
            builder.Ignore(m => m.Id);
            builder.Ignore(m => m.UpdatedDate);
            builder.HasKey(m => new { m.IngredientId, m.MenuId });
        }
    }
}

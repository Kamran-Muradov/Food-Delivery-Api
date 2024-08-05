using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class CheckoutConfiguration : IEntityTypeConfiguration<Checkout>
    {
        public void Configure(EntityTypeBuilder<Checkout> builder)
        {
            builder
                .HasOne<AppUser>(m => m.User)
                .WithMany(appUser => appUser.Checkouts)
                .HasForeignKey(m => m.UserId);
        }
    }
}

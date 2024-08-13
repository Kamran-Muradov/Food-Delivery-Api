using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class UserImageConfiguration : IEntityTypeConfiguration<UserImage>
    {
        public void Configure(EntityTypeBuilder<UserImage> builder)
        {
            builder
                .HasOne<AppUser>(m => m.User)
                .WithOne(appUser => appUser.UserImage)
                .HasForeignKey<UserImage>(m => m.UserId);
        }
    }
}

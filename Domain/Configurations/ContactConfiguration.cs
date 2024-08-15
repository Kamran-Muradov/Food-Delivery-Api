using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(c => c.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Subject)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Message)
                .IsRequired();

            builder.Ignore(c => c.CreatedBy);
            builder.Ignore(c => c.UpdatedBy);
        }
    }
}

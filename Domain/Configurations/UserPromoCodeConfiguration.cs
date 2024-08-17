using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class UserPromoCodeConfiguration : IEntityTypeConfiguration<UserPromoCode>
    {
        public void Configure(EntityTypeBuilder<UserPromoCode> builder)
        {
            builder
                .Ignore(upc => upc.CreatedDate)
                .Ignore(upc => upc.CreatedBy)
                .Ignore(upc => upc.UpdatedDate)
                .Ignore(upc => upc.UpdatedBy);
        }
    }
}

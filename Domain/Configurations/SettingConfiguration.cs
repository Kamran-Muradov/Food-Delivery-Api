﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.Property(m => m.Key)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Value)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}

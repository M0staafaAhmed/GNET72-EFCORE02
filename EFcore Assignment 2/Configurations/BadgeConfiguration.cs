using EFcore_Assignment_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFcore_Assignment_2.Configurations
{
    internal class BadgeConfiguration : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.ToTable("Badges");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.BadgeNumber)
                .IsRequired();

            builder.HasIndex(b => b.BadgeNumber)
                .IsUnique();

            builder.Property(b => b.IssuedDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(b => b.Tier)
               .IsRequired()
               .HasConversion<string>();

            builder.HasOne(b => b.Attendee)
                .WithOne(a => a.Badge)
                .HasForeignKey<Badge>(b => b.AttendeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(b => b.AttendeeId).IsUnique();
        }
    }
}

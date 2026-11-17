using EFcore_Assignment_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFcore_Assignment_2.Configurations
{
    internal class OrganizerProfileConfiguration : IEntityTypeConfiguration<OrganizerProfile>
    {
        public void Configure(EntityTypeBuilder<OrganizerProfile> builder)
        {
            builder.ToTable("OrganizerProfiles");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Biography)
                   .HasMaxLength(1000);

            builder.Property(p => p.WebsiteUrl)
                   .HasMaxLength(300);

            builder.Property(p => p.Logo);

            builder.HasOne(p => p.Organizer)
                   .WithOne(o => o.Profile)
                   .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.OrganizerId).IsUnique();
        }
    }
}

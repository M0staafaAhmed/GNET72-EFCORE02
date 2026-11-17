using EFcore_Assignment_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFcore_Assignment_2.Configurations
{
    internal class EventConfigration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
             .IsRequired()
             .HasMaxLength(200);

            builder.Property(x => x.Description)
             .IsRequired()
             .HasMaxLength(4000);

            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired(false);
            builder.Property(x => x.MaxAttendees).IsRequired();

            builder.HasOne(x => x.Organizer)
             .WithMany(o => o.Events)
             .HasForeignKey(x => x.OrganizerId)
             .IsRequired()
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

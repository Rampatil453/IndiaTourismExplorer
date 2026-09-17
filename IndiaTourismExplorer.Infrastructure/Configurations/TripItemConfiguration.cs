using IndiaTourismExplorer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Infrastructure.Configurations
{
    public class TripItemConfiguration: IEntityTypeConfiguration<TripItem>
    {
        public void Configure(EntityTypeBuilder<TripItem> builder)
        {
            builder.HasKey(x => x.TripItemId);

            builder.Property(x => x.Notes)
                .HasMaxLength(1000);

            builder.HasOne(x => x.Trip)
                .WithMany(x => x.TripItems)
                .HasForeignKey(x => x.TripId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.TouristPlace)
                .WithMany(x => x.TripItems)
                .HasForeignKey(x => x.TouristPlaceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new
            {
                x.TripId,
                x.DayNumber,
                x.DisplayOrder
            });
        }
    }
}

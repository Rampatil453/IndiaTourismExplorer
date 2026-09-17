using IndiaTourismExplorer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Infrastructure.Configurations
{
    public class NearbyPlaceConfiguration: IEntityTypeConfiguration<NearbyPlace>
    {
        public void Configure(EntityTypeBuilder<NearbyPlace> builder)
        {
            builder.HasKey(x => x.NearbyPlaceId);

            builder.Property(x => x.DistanceKm)
                .HasPrecision(8, 2);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            // Main Tourist Place
            builder.HasOne(x => x.TouristPlace)
                .WithMany(x => x.NearbyPlaces)
                .HasForeignKey(x => x.TouristPlaceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Nearby Tourist Place
            builder.HasOne(x => x.NearbyTouristPlace)
                .WithMany()
                .HasForeignKey(x => x.NearbyTouristPlaceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Prevent duplicate nearby-place relationships
            builder.HasIndex(x => new
            {
                x.TouristPlaceId,
                x.NearbyTouristPlaceId
            })
            .IsUnique();
        }
    }
}

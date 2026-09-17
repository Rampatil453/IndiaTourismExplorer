using IndiaTourismExplorer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Infrastructure.Configurations
{
    public class TouristPlaceConfiguration: IEntityTypeConfiguration<TouristPlace>
    {
        public void Configure(EntityTypeBuilder<TouristPlace> builder)
        {
            builder.HasKey(x => x.TouristPlaceId);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.ShortDescription)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.Address)
                .HasMaxLength(500);

            builder.Property(x => x.Latitude)
                .HasPrecision(9, 6);

            builder.Property(x => x.Longitude)
                .HasPrecision(9, 6);

            builder.HasOne(x => x.Location)
                .WithMany(x => x.TouristPlaces)
                .HasForeignKey(x => x.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

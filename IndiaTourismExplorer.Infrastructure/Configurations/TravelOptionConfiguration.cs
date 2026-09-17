using IndiaTourismExplorer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Infrastructure.Configurations
{
    public class TravelOptionConfiguration: IEntityTypeConfiguration<TravelOption>
    {
        public void Configure(EntityTypeBuilder<TravelOption> builder)
        {
            builder.HasKey(x => x.TravelOptionId);

            builder.Property(x => x.TransportType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasOne(x => x.TouristPlace)
                .WithMany(x => x.TravelOptions)
                .HasForeignKey(x => x.TouristPlaceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

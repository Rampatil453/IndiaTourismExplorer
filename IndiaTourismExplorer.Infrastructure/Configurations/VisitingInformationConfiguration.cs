using IndiaTourismExplorer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Infrastructure.Configurations
{
    public class VisitingInformationConfiguration: IEntityTypeConfiguration<VisitingInformation>
    {
        public void Configure(EntityTypeBuilder<VisitingInformation> builder)
        {
            builder.HasKey(x => x.VisitingInformationId);

            builder.Property(x => x.BestTimeToVisit)
                .HasMaxLength(200);

            builder.Property(x => x.EntryFee)
                .HasPrecision(10, 2);

            builder.Property(x => x.AgeRestriction)
                .HasMaxLength(100);

            builder.Property(x => x.BookingUrl)
                .HasMaxLength(500);

            builder.Property(x => x.AdditionalInformation)
                .HasMaxLength(2000);

            builder.HasOne(x => x.TouristPlace)
                .WithOne(x => x.VisitingInformation)
                .HasForeignKey<VisitingInformation>(
                    x => x.TouristPlaceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.TouristPlaceId)
                .IsUnique();
        }
    }
}

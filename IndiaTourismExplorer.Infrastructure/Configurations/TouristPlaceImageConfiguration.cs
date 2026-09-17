using IndiaTourismExplorer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Infrastructure.Configurations
{
    public class TouristPlaceImageConfiguration: IEntityTypeConfiguration<TouristPlaceImage>
    {
        public void Configure(EntityTypeBuilder<TouristPlaceImage> builder)
        {
            builder.HasKey(x => x.ImageId);

            builder.Property(x => x.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.AltText)
                .HasMaxLength(250);

            builder.HasOne(x => x.TouristPlace)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.TouristPlaceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new
            {
                x.TouristPlaceId,
                x.DisplayOrder
            });
        }
    }
}

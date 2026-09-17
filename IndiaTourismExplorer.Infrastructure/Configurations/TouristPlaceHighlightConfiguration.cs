using IndiaTourismExplorer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Infrastructure.Configurations
{
    public class TouristPlaceHighlightConfiguration : IEntityTypeConfiguration<TouristPlaceHighlight>
    {
        public void Configure(EntityTypeBuilder<TouristPlaceHighlight> builder)
        {
            builder.HasKey(x => x.HighlightId);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.HasOne(x => x.TouristPlace)
                .WithMany(x => x.Highlights)
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

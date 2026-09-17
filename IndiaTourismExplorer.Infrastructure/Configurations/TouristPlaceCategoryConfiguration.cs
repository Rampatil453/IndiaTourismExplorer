using IndiaTourismExplorer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Infrastructure.Configurations
{
    public class TouristPlaceCategoryConfiguration: IEntityTypeConfiguration<TouristPlaceCategory>
    {
        public void Configure(EntityTypeBuilder<TouristPlaceCategory> builder)
        {
            builder.HasKey(x => new
            {
                x.TouristPlaceId,
                x.CategoryId
            });

            builder.HasOne(x => x.TouristPlace)
                .WithMany(x => x.TouristPlaceCategories)
                .HasForeignKey(x => x.TouristPlaceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.TouristPlaceCategories)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

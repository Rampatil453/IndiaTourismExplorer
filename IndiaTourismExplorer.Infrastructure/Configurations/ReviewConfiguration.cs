using IndiaTourismExplorer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Infrastructure.Configurations
{
    public class ReviewConfiguration: IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.ReviewId);

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(x => x.Rating)
                .IsRequired();

            builder.Property(x => x.Comment)
                .HasMaxLength(2000);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.TouristPlace)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.TouristPlaceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Helpful for retrieving reviews for a tourist place
            builder.HasIndex(x => x.TouristPlaceId);

            // Helpful for filtering by review status
            builder.HasIndex(x => x.Status);
        }
    }
}

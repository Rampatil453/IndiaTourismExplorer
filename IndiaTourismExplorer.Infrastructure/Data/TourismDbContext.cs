using IndiaTourismExplorer.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Infrastructure.Data
{
    public class TourismDbContext : IdentityDbContext<ApplicationUser>
    {
        public TourismDbContext(DbContextOptions<TourismDbContext> options)
        : base(options)
        {
        }

        public DbSet<State> States { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TouristPlace> TouristPlaces { get; set; }
        public DbSet<TouristPlaceCategory> TouristPlaceCategories { get; set; }
        public DbSet<TouristPlaceImage> TouristPlaceImages { get; set; }
        public DbSet<TouristPlaceHighlight> TouristPlaceHighlights { get; set; }
        public DbSet<VisitingInformation> VisitingInformations { get; set; }
        public DbSet<TravelOption> TravelOptions { get; set; }
        public DbSet<NearbyPlace> NearbyPlaces { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripItem> TripItems { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(TourismDbContext).Assembly);
        }
    }
}

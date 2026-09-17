using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Domain.Entities
{
    public class TouristPlace
    {
        public int TouristPlaceId { get; set; }

        public int LocationId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ShortDescription { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? Address { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public bool IsFeatured { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties

        public Location Location { get; set; } = null!;

        public ICollection<TouristPlaceCategory> TouristPlaceCategories { get; set; }
            = new List<TouristPlaceCategory>();

        public ICollection<TouristPlaceImage> Images { get; set; }
            = new List<TouristPlaceImage>();

        public ICollection<TouristPlaceHighlight> Highlights { get; set; }
            = new List<TouristPlaceHighlight>();

        public VisitingInformation? VisitingInformation { get; set; }

        public ICollection<TravelOption> TravelOptions { get; set; }
            = new List<TravelOption>();

        public ICollection<NearbyPlace> NearbyPlaces { get; set; }
            = new List<NearbyPlace>();

        public ICollection<Review> Reviews { get; set; }
            = new List<Review>();

        public ICollection<Favorite> Favorites { get; set; }
            = new List<Favorite>();

        public ICollection<TripItem> TripItems { get; set; }
            = new List<TripItem>();

    }
}

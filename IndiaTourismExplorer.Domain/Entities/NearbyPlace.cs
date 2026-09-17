using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Domain.Entities
{
    public class NearbyPlace
    {
        public int NearbyPlaceId { get; set; }

        public int TouristPlaceId { get; set; }

        public int NearbyTouristPlaceId { get; set; }

        public decimal? DistanceKm { get; set; }

        public string? Description { get; set; }

        // Navigation properties
        public TouristPlace TouristPlace { get; set; } = null!;

        public TouristPlace NearbyTouristPlace { get; set; } = null!;
    }
}

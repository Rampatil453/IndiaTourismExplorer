using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Domain.Entities
{
    public class TravelOption
    {
        public int TravelOptionId { get; set; }

        public int TouristPlaceId { get; set; }

        public string TransportType { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        // Navigation property
        public TouristPlace TouristPlace { get; set; } = null!;
    }
}

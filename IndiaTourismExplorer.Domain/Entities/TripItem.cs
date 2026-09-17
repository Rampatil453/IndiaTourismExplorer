using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Domain.Entities
{
    public class TripItem
    {
        public int TripItemId { get; set; }

        public int TripId { get; set; }

        public int TouristPlaceId { get; set; }

        public DateTime? VisitDate { get; set; }

        public int? DayNumber { get; set; }

        public int DisplayOrder { get; set; }

        public string? Notes { get; set; }

        // Navigation properties

        public Trip Trip { get; set; } = null!;

        public TouristPlace TouristPlace { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Domain.Entities
{
    public class VisitingInformation
    {
        public int VisitingInformationId { get; set; }

        public int TouristPlaceId { get; set; }

        public string? BestTimeToVisit { get; set; }

        public TimeSpan? OpeningTime { get; set; }

        public TimeSpan? ClosingTime { get; set; }

        public decimal? EntryFee { get; set; }

        public int? RecommendedDurationMinutes { get; set; }

        public string? AgeRestriction { get; set; }

        public bool BookingRequired { get; set; } = false;

        public string? BookingUrl { get; set; }

        public string? AdditionalInformation { get; set; }

        // Navigation property
        public TouristPlace TouristPlace { get; set; } = null!;

    }
}

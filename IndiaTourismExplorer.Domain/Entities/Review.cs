using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Domain.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public int TouristPlaceId { get; set; }

        public int Rating { get; set; }

        public string? Comment { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties

        public ApplicationUser User { get; set; } = null!;

        public TouristPlace TouristPlace { get; set; } = null!;
    }
}

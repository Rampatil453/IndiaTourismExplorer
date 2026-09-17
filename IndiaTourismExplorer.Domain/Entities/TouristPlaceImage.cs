using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Domain.Entities
{
    public class TouristPlaceImage
    {
        public int ImageId { get; set; }

        public int TouristPlaceId { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public string? AltText { get; set; }

        public bool IsPrimary { get; set; } = false;

        public int DisplayOrder { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation property
        public TouristPlace TouristPlace { get; set; } = null!;
    }
}

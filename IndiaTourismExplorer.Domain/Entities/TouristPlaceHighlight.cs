using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Domain.Entities
{
    public class TouristPlaceHighlight
    {
        public int HighlightId { get; set; }

        public int TouristPlaceId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int DisplayOrder { get; set; }

        // Navigation property
        public TouristPlace TouristPlace { get; set; } = null!;
    }
}

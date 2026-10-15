using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IndiaTourismExplorer.Domain.Entities
{
    public class TouristPlaceHighlight
    {
        public int TouristPlaceHighlightId { get; set; }

        public int TouristPlaceId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int DisplayOrder { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string HighlightText { get; set; } = string.Empty;

        // Navigation property
        public TouristPlace TouristPlace { get; set; } = null!;
    }
}

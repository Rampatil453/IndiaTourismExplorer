using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.DTOs
{
     public class AdminTouristPlaceImageDto
    {
        public int TouristPlaceImageId { get; set; }
        public int TouristPlaceId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string? AltText { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsPrimary { get; set; }
    }
}

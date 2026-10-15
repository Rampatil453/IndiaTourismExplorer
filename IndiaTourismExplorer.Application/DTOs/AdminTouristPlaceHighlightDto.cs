using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IndiaTourismExplorer.Application.DTOs
{
    public sealed class AdminTouristPlaceHighlightDto
    {
        public int HighlightId { get; set; }
        [Range(1,int.MaxValue)]
        public int TouristPlaceId { get; set; }
        public string Highlight { get; set; } = string.Empty;
        public int TouristPlaceHighlightId { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string HighlightText { get; set; } = string.Empty;
        
    }
}

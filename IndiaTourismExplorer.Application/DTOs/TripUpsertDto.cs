using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IndiaTourismExplorer.Application.DTOs
{
    public sealed class TripUpsertDto
    {
        [Required, StringLength(120)]
        public string Name { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public sealed class TripDto
    {
        public int TripId { get; set; }
        public string Name { get; set; } = "";
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

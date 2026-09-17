using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Domain.Entities
{
    public class Trip
    {
        public int TripId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties

        public ApplicationUser User { get; set; } = null!;

        public ICollection<TripItem> TripItems { get; set; }
            = new List<TripItem>();
    }
}

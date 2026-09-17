using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Domain.Entities
{
    public class State
    {
        public int StateId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation property
        public ICollection<Location> Locations { get; set; } = new List<Location>();
    }
}

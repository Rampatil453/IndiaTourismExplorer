using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Domain.Entities
{
    public class TouristPlaceCategory
    {
        public int TouristPlaceId { get; set; }

        public int CategoryId { get; set; }

        // Navigation properties

        public TouristPlace TouristPlace { get; set; } = null!;

        public Category Category { get; set; } = null!;
    }
}

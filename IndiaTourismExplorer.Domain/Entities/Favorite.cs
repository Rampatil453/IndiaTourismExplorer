using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Domain.Entities
{
    public class Favorite
    {
        public int FavoriteId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public int TouristPlaceId { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation properties

        public ApplicationUser User { get; set; } = null!;

        public TouristPlace TouristPlace { get; set; } = null!;
    }
}

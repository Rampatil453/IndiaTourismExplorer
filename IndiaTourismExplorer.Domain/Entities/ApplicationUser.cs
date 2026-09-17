using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Domain.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public string? FullName { get; set; }

        public string? ProfileImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties

        public ICollection<Favorite> Favorites { get; set; }
            = new List<Favorite>();

        public ICollection<Review> Reviews { get; set; }
            = new List<Review>();

        public ICollection<Trip> Trips { get; set; }
            = new List<Trip>();

        public ICollection<Feedback> Feedbacks { get; set; }
            = new List<Feedback>();
    }
}

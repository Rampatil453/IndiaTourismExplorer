using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Domain.Entities
{
    public class Feedback
    {
        public int FeedbackId { get; set; }

        public string? UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public string Status { get; set; } = "New";

        public DateTime CreatedAt { get; set; }

        // Navigation property

        public ApplicationUser? User { get; set; }
    }
}

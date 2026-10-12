namespace IndiaTourismExplorer.Application.DTOs;

public sealed class AdminFeedbackDto
{
    public int FeedbackId { get; set; }

    public string? UserId { get; set; }

    public string? UserEmail { get; set; }

    public string Message { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}
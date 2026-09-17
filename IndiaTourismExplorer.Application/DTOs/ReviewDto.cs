namespace IndiaTourismExplorer.Application.DTOs;

public class ReviewDto
{
    public int ReviewId { get; set; }

    public int TouristPlaceId { get; set; }

    public string TouristPlaceName { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}
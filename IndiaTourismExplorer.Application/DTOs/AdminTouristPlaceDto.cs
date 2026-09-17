namespace IndiaTourismExplorer.Application.DTOs;

public class AdminTouristPlaceDto
{
    public int TouristPlaceId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int LocationId { get; set; }

    public string? Address { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public bool IsFeatured { get; set; }

    public bool IsActive { get; set; }
}
namespace IndiaTourismExplorer.Application.DTOs;

public class TouristPlaceDto
{
    public int TouristPlaceId { get; set; }
    public int LocationId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string ShortDescription { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string? Address { get; set; }

    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }

    public bool IsFeatured { get; set; }

    public List<string> Categories { get; set; } = new();
}
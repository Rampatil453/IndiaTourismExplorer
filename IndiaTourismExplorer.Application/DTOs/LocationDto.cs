namespace IndiaTourismExplorer.Application.DTOs;

public class LocationDto
{
    public int LocationId { get; set; }
    public int StateId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
}
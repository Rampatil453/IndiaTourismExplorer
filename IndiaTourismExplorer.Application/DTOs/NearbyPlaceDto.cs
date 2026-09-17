namespace IndiaTourismExplorer.Application.DTOs;

public class NearbyPlaceDto
{
    public int NearbyPlaceId { get; set; }
    public int TouristPlaceId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal? DistanceKm { get; set; }
    public string? Description { get; set; }
}
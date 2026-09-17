namespace IndiaTourismExplorer.Application.DTOs;

public class TouristPlaceDetailsDto
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

    public List<TouristPlaceImageDto> Images { get; set; } = new();

    public List<TouristPlaceHighlightDto> Highlights { get; set; } = new();

    public VisitingInformationDto? VisitingInformation { get; set; }

    public List<TravelOptionDto> TravelOptions { get; set; } = new();

    public List<NearbyPlaceDto> NearbyPlaces { get; set; } = new();
}
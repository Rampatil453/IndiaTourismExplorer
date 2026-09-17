namespace IndiaTourismExplorer.Application.DTOs;

public class TravelOptionDto
{
    public int TravelOptionId { get; set; }
    public string TransportType { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
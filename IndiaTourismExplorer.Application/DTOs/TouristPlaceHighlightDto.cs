namespace IndiaTourismExplorer.Application.DTOs;

public class TouristPlaceHighlightDto
{
    public int HighlightId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int DisplayOrder { get; set; }
}
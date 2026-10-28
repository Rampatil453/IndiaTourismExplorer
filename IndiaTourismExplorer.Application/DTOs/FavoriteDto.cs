namespace IndiaTourismExplorer.Application.DTOs;

public class FavoriteDto
{
    public int FavoriteId { get; set; }

    public int TouristPlaceId { get; set; }

    public string TouristPlaceName { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}
public sealed class FavoriteSummaryDto
{
    public int TouristPlaceId { get; set; }
    public int FavoriteCount { get; set; }
}
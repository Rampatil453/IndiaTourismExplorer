using System.ComponentModel.DataAnnotations;

namespace IndiaTourismExplorer.Application.DTOs;

public class AdminReviewDto
{
    public int ReviewId { get; set; }

    public int TouristPlaceId { get; set; }

    public string TouristPlaceName { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string UserEmail { get; set; } = string.Empty;

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public string Status { get; set; } = "";

    public DateTime CreatedAt { get; set; }
}
public sealed class UpdateReviewStatusDto
{
    [Required]
    [RegularExpression("^(Approved|Rejected)$", ErrorMessage = "Status must be Approved or Rejected.")]
    public string Status { get; set; } = "";
}
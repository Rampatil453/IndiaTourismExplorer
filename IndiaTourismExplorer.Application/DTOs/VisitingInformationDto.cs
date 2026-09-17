namespace IndiaTourismExplorer.Application.DTOs;

public class VisitingInformationDto
{
    public string? BestTimeToVisit { get; set; }
    public TimeSpan? OpeningTime { get; set; }
    public TimeSpan? ClosingTime { get; set; }
    public decimal? EntryFee { get; set; }
    public int? RecommendedDurationMinutes { get; set; }
    public string? AgeRestriction { get; set; }
    public bool BookingRequired { get; set; }
    public string? BookingUrl { get; set; }
    public string? AdditionalInformation { get; set; }
}
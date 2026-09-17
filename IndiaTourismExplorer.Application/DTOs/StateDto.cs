namespace IndiaTourismExplorer.Application.DTOs;

public class StateDto
{
    public int StateId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}
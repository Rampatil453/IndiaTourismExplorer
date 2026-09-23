namespace IndiaTourismExplorer.Application.DTOs;

public class AdminStateDto
{
    public int StateId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Code { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; } = true;
}
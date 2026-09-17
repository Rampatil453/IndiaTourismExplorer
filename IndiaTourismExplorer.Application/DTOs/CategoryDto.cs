namespace IndiaTourismExplorer.Application.DTOs;

public class CategoryDto
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Icon { get; set; }

    public string? ImageUrl { get; set; }
}
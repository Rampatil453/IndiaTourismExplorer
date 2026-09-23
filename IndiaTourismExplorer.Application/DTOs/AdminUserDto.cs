namespace IndiaTourismExplorer.Application.DTOs;

public class AdminUserDto
{
    public string UserId { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public bool EmailConfirmed { get; set; }

    public bool IsActive { get; set; }

    public List<string> Roles { get; set; } = new();
}
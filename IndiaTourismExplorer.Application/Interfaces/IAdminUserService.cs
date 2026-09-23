using IndiaTourismExplorer.Application.DTOs;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface IAdminUserService
{
    Task<List<AdminUserDto>> GetAllAsync();

    Task<AdminUserDto?> GetByIdAsync(string userId);
    Task<bool> UpdateStatusAsync(
    string userId,
    bool isActive);
}
using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace IndiaTourismExplorer.Application.Services;

public class AdminUserService : IAdminUserService
{
    private readonly IAdminUserRepository _repository;
    private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;

    public AdminUserService(
        IAdminUserRepository repository,
        UserManager<Domain.Entities.ApplicationUser> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }

    public async Task<List<AdminUserDto>> GetAllAsync()
    {
        var users = await _repository.GetAllAsync();
        var result = new List<AdminUserDto>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);

            result.Add(new AdminUserDto
            {
                UserId = user.Id,
                FullName = user.UserName ?? string.Empty,
                Email = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber,
                EmailConfirmed = user.EmailConfirmed,
                IsActive = true,
                Roles = roles.ToList()
            });
        }

        return result;
    }

    public async Task<AdminUserDto?> GetByIdAsync(string userId)
    {
        var user = await _repository.GetByIdAsync(userId);

        if (user == null)
        {
            return null;
        }

        var roles = await _userManager.GetRolesAsync(user);

        return new AdminUserDto
        {
            UserId = user.Id,
            FullName = user.UserName ?? string.Empty,
            Email = user.Email ?? string.Empty,
            PhoneNumber = user.PhoneNumber,
            EmailConfirmed = user.EmailConfirmed,
            IsActive = user.IsActive,
            Roles = roles.ToList()
        };
    }
    public async Task<bool> UpdateStatusAsync(
    string userId,
    bool isActive)
    {
        var user = await _repository.GetByIdAsync(userId);

        if (user == null)
        {
            return false;
        }

        user.IsActive = isActive;

        await _repository.SaveChangesAsync();

        return true;
    }
}
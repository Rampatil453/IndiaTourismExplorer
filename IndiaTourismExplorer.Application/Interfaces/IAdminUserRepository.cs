using IndiaTourismExplorer.Domain.Entities;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface IAdminUserRepository
{
    Task<List<ApplicationUser>> GetAllAsync();

    Task<ApplicationUser?> GetByIdAsync(string userId);

    Task SaveChangesAsync();
}
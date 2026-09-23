using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;
using IndiaTourismExplorer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IndiaTourismExplorer.Infrastructure.Repositories;

public class AdminUserRepository : IAdminUserRepository
{
    private readonly TourismDbContext _context;

    public AdminUserRepository(TourismDbContext context)
    {
        _context = context;
    }

    public async Task<List<ApplicationUser>> GetAllAsync()
    {
        return await _context.Users
            .OrderBy(x => x.Email)
            .ToListAsync();
    }

    public async Task<ApplicationUser?> GetByIdAsync(string userId)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Id == userId);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
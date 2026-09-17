using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;
using IndiaTourismExplorer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IndiaTourismExplorer.Infrastructure.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly TourismDbContext _context;

    public LocationRepository(TourismDbContext context)
    {
        _context = context;
    }

    public async Task<List<Location>> GetByStateIdAsync(int stateId)
    {
        return await _context.Locations
            .Where(x => x.StateId == stateId && x.IsActive)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Location?> GetByIdAsync(int id)
    {
        return await _context.Locations
            .FirstOrDefaultAsync(x => x.LocationId == id && x.IsActive);
    }
}
using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;
using IndiaTourismExplorer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IndiaTourismExplorer.Infrastructure.Repositories;

public sealed class AdminVisitingInformationRepository : IAdminVisitingInformationRepository
{
    private readonly TourismDbContext _context;
    public AdminVisitingInformationRepository(TourismDbContext context) => _context = context;

    public async Task<List<VisitingInformation>> GetByTouristPlaceIdAsync(int touristPlaceId) =>
        await _context.VisitingInformations
            .AsNoTracking()
            .Where(x => x.TouristPlaceId == touristPlaceId)
            .OrderBy(x => x.VisitingInformationId)
            .ToListAsync();

    public Task<VisitingInformation?> GetByIdAsync(int id) =>
        _context.VisitingInformations.FirstOrDefaultAsync(x => x.VisitingInformationId == id);

    public Task<bool> TouristPlaceExistsAsync(int touristPlaceId) =>
        _context.TouristPlaces.AnyAsync(x => x.TouristPlaceId == touristPlaceId);

    public async Task<VisitingInformation> AddAsync(VisitingInformation entity)
    {
        _context.VisitingInformations.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(VisitingInformation entity)
    {
        _context.VisitingInformations.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.VisitingInformations.FindAsync(id);
        if (entity is null) return false;
        _context.VisitingInformations.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
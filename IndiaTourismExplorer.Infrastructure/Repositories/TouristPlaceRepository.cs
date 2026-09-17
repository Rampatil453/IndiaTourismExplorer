using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;
using IndiaTourismExplorer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IndiaTourismExplorer.Infrastructure.Repositories;

public class TouristPlaceRepository : ITouristPlaceRepository
{
    private readonly TourismDbContext _context;

    public TouristPlaceRepository(TourismDbContext context)
    {
        _context = context;
    }

    public async Task<List<TouristPlace>> GetByLocationIdAsync(
        int locationId)
    {
        return await _context.TouristPlaces
            .Include(x => x.TouristPlaceCategories)
                .ThenInclude(x => x.Category)
            .Where(x =>
                x.LocationId == locationId &&
                x.IsActive)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<TouristPlace?> GetByIdAsync(int id)
    {
        return await _context.TouristPlaces
            .Include(x => x.TouristPlaceCategories)
                .ThenInclude(x => x.Category)
            .FirstOrDefaultAsync(x =>
                x.TouristPlaceId == id &&
                x.IsActive);
    }
    public async Task<List<TouristPlace>> GetByCategoryIdAsync(int categoryId)
    {
        return await _context.TouristPlaces
            .Include(x => x.TouristPlaceCategories)
                .ThenInclude(x => x.Category)
            .Where(x =>
                x.IsActive &&
                x.TouristPlaceCategories.Any(tc =>
                    tc.CategoryId == categoryId))
            .OrderBy(x => x.Name)
            .ToListAsync();
    }
    public async Task<TouristPlace?> GetDetailsByIdAsync(int id)
    {
        return await _context.TouristPlaces
            .Include(x => x.Location)

            .Include(x => x.TouristPlaceCategories)
                .ThenInclude(x => x.Category)

            .Include(x => x.Images)

            .Include(x => x.Highlights)

            .Include(x => x.VisitingInformation)

            .Include(x => x.TravelOptions)

            .Include(x => x.NearbyPlaces)
                .ThenInclude(x => x.NearbyTouristPlace)

            .FirstOrDefaultAsync(x =>
                x.TouristPlaceId == id &&
                x.IsActive);
    }
    public async Task<List<TouristPlace>> GetFeaturedAsync()
    {
        return await _context.TouristPlaces
            .Include(x => x.TouristPlaceCategories)
                .ThenInclude(x => x.Category)
            .Where(x => x.IsActive && x.IsFeatured)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }
}
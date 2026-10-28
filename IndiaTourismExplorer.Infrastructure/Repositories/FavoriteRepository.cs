using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;
using IndiaTourismExplorer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IndiaTourismExplorer.Infrastructure.Repositories;

public class FavoriteRepository : IFavoriteRepository
{
    private readonly TourismDbContext _context;

    public FavoriteRepository(TourismDbContext context)
    {
        _context = context;
    }

    public async Task<Favorite?> GetByUserAndPlaceAsync(
        string userId,
        int touristPlaceId)
    {
        return await _context.Favorites
            .Include(x => x.TouristPlace)
            .FirstOrDefaultAsync(x =>
                x.UserId == userId &&
                x.TouristPlaceId == touristPlaceId);
    }

    public async Task<List<Favorite>> GetByUserIdAsync(
        string userId)
    {
        return await _context.Favorites
            .Include(x => x.TouristPlace)
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

    public async Task AddAsync(Favorite favorite)
    {
        await _context.Favorites.AddAsync(favorite);
    }

    public void Remove(Favorite favorite)
    {
        _context.Favorites.Remove(favorite);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    // Add to existing FavoriteRepository, using existing _db: TourismDbContext
    public Task<List<Favorite>> ListMineAsync(string userId)
    {
        return _context.Favorites.AsNoTracking()
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public Task<Favorite?> FindMineAsync(string userId, int placeId)
    {
        return _context.Favorites.FirstOrDefaultAsync(x =>
            x.UserId == userId && x.TouristPlaceId == placeId);
    }
    public Task<bool> PlaceExistsAsync(int placeId)
    {
        return _context.TouristPlaces.AnyAsync(x => x.TouristPlaceId == placeId);
    }
    public Task<List<FavoriteSummaryDto>> SummaryAsync()
    {
       return _context.Favorites.AsNoTracking()
            .GroupBy(x => x.TouristPlaceId)
            .Select(g => new FavoriteSummaryDto
            {
                TouristPlaceId = g.Key,
                FavoriteCount = g.Count()
            }).ToListAsync();
    }
}
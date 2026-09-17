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
}
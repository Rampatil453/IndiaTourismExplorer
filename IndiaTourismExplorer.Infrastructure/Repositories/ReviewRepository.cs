using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;
using IndiaTourismExplorer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IndiaTourismExplorer.Infrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly TourismDbContext _context;

    public ReviewRepository(TourismDbContext context)
    {
        _context = context;
    }

    public async Task<List<Review>> GetByTouristPlaceIdAsync(
        int touristPlaceId)
    {
        return await _context.Reviews
            .Include(x => x.User)
            .Include(x => x.TouristPlace)
            .Where(x =>
                x.TouristPlaceId == touristPlaceId &&
                x.Status == "Approved")
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

    public async Task<Review?> GetByIdAsync(int reviewId)
    {
        return await _context.Reviews
            .Include(x => x.User)
            .Include(x => x.TouristPlace)
            .FirstOrDefaultAsync(x => x.ReviewId == reviewId);
    }

    public async Task AddAsync(Review review)
    {
        await _context.Reviews.AddAsync(review);
    }
    public async Task<List<Review>> GetAllAsync()
    {
        return await _context.Reviews
            .Include(x => x.User)
            .Include(x => x.TouristPlace)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

    public void Update(Review review)
    {
        _context.Reviews.Update(review);
    }

    public void Remove(Review review)
    {
        _context.Reviews.Remove(review);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
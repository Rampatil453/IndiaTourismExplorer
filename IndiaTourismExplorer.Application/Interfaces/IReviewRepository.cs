using IndiaTourismExplorer.Domain.Entities;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface IReviewRepository
{
    Task<List<Review>> GetByTouristPlaceIdAsync(
        int touristPlaceId);

    Task<Review?> GetByIdAsync(int reviewId);

    Task<List<Review>> GetAllAsync();

    Task AddAsync(Review review);

    void Update(Review review);

    void Remove(Review review);

    Task SaveChangesAsync();
}
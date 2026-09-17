using IndiaTourismExplorer.Application.DTOs;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface IReviewService
{
    Task<bool> AddReviewAsync(string userId, int touristPlaceId, int rating, string? comment);

    Task<List<ReviewDto>> GetReviewsByTouristPlaceIdAsync(int touristPlaceId);

    Task<bool> UpdateReviewAsync(
        string userId,
        int reviewId,
        int rating,
        string? comment);

    Task<bool> DeleteReviewAsync(string userId, int reviewId);

    Task<List<AdminReviewDto>> GetAllReviewsAsync();

    Task<bool> UpdateReviewStatusAsync(
        int reviewId,
        string status);
}
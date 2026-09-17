using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;

namespace IndiaTourismExplorer.Infrastructure.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<bool> AddReviewAsync(
        string userId,
        int touristPlaceId,
        int rating,
        string? comment)
    {
        if (rating < 1 || rating > 5)
            return false;

        var review = new Review
        {
            UserId = userId,
            TouristPlaceId = touristPlaceId,
            Rating = rating,
            Comment = comment,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow
        };

        await _reviewRepository.AddAsync(review);
        await _reviewRepository.SaveChangesAsync();

        return true;
    }

    public async Task<List<ReviewDto>> GetReviewsByTouristPlaceIdAsync(
        int touristPlaceId)
    {
        var reviews =
            await _reviewRepository.GetByTouristPlaceIdAsync(touristPlaceId);

        return reviews.Select(x => new ReviewDto
        {
            ReviewId = x.ReviewId,
            TouristPlaceId = x.TouristPlaceId,
            TouristPlaceName = x.TouristPlace?.Name ?? string.Empty,
            UserName = x.User?.FullName ?? string.Empty,
            Rating = x.Rating,
            Comment = x.Comment,
            Status = x.Status,
            CreatedAt = x.CreatedAt
        }).ToList();
    }

    public async Task<bool> UpdateReviewAsync(
        string userId,
        int reviewId,
        int rating,
        string? comment)
    {
        if (rating < 1 || rating > 5)
            return false;

        var review = await _reviewRepository.GetByIdAsync(reviewId);

        if (review == null || review.UserId != userId)
            return false;

        review.Rating = rating;
        review.Comment = comment;
        review.Status = "Pending";
        review.UpdatedAt = DateTime.UtcNow;

        _reviewRepository.Update(review);
        await _reviewRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteReviewAsync(
        string userId,
        int reviewId)
    {
        var review = await _reviewRepository.GetByIdAsync(reviewId);

        if (review == null || review.UserId != userId)
            return false;

        _reviewRepository.Remove(review);
        await _reviewRepository.SaveChangesAsync();

        return true;
    }
    public async Task<List<AdminReviewDto>> GetAllReviewsAsync()
    {
        var reviews = await _reviewRepository.GetAllAsync();

        return reviews.Select(x => new AdminReviewDto
        {
            ReviewId = x.ReviewId,
            TouristPlaceId = x.TouristPlaceId,
            TouristPlaceName = x.TouristPlace?.Name ?? string.Empty,
            UserName = x.User?.FullName ?? string.Empty,
            UserEmail = x.User?.Email ?? string.Empty,
            Rating = x.Rating,
            Comment = x.Comment,
            Status = x.Status,
            CreatedAt = x.CreatedAt
        }).ToList();
    }
    public async Task<bool> UpdateReviewStatusAsync(
    int reviewId,
    string status)
    {
        if (status != "Approved" &&
            status != "Rejected")
        {
            return false;
        }

        var review = await _reviewRepository.GetByIdAsync(reviewId);

        if (review == null)
            return false;

        review.Status = status;
        review.UpdatedAt = DateTime.UtcNow;

        _reviewRepository.Update(review);

        await _reviewRepository.SaveChangesAsync();

        return true;
    }
}
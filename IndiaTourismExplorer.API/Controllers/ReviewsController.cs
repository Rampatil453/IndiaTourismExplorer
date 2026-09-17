using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IndiaTourismExplorer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    // Get approved reviews for a tourist place
    [HttpGet("place/{touristPlaceId:int}")]
    public async Task<ActionResult<List<ReviewDto>>> GetReviews(
        int touristPlaceId)
    {
        var reviews =
            await _reviewService.GetReviewsByTouristPlaceIdAsync(
                touristPlaceId);

        return Ok(reviews);
    }

    // Add review
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddReview(
        int touristPlaceId,
        int rating,
        string? comment)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var result = await _reviewService.AddReviewAsync(
            userId,
            touristPlaceId,
            rating,
            comment);

        if (!result)
            return BadRequest(new
            {
                message = "Rating must be between 1 and 5."
            });

        return Ok(new
        {
            message = "Review submitted successfully and is pending approval."
        });
    }

    // Update own review
    [Authorize]
    [HttpPut("{reviewId:int}")]
    public async Task<IActionResult> UpdateReview(
        int reviewId,
        int rating,
        string? comment)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var result = await _reviewService.UpdateReviewAsync(
            userId,
            reviewId,
            rating,
            comment);

        if (!result)
            return BadRequest(new
            {
                message = "Review not found, unauthorized, or invalid rating."
            });

        return Ok(new
        {
            message = "Review updated successfully and is pending approval."
        });
    }

    // Delete own review
    [Authorize]
    [HttpDelete("{reviewId:int}")]
    public async Task<IActionResult> DeleteReview(int reviewId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var result = await _reviewService.DeleteReviewAsync(
            userId,
            reviewId);

        if (!result)
            return NotFound(new
            {
                message = "Review not found or unauthorized."
            });

        return Ok(new
        {
            message = "Review deleted successfully."
        });
    }
}
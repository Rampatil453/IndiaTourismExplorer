using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTourismExplorer.API.Controllers;

[ApiController]
[Route("api/admin/reviews")]
[Authorize(Roles = "Admin")]
public class AdminReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public AdminReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    // Get all reviews
    [HttpGet]
    public async Task<ActionResult<List<AdminReviewDto>>> GetAllReviews()
    {
        var reviews = await _reviewService.GetAllReviewsAsync();

        return Ok(reviews);
    }

    // Approve review
    [HttpPut("{reviewId:int}/approve")]
    public async Task<IActionResult> ApproveReview(int reviewId)
    {
        var result = await _reviewService.UpdateReviewStatusAsync(
            reviewId,
            "Approved");

        if (!result)
        {
            return NotFound(new
            {
                message = "Review not found."
            });
        }

        return Ok(new
        {
            message = "Review approved successfully."
        });
    }

    // Reject review
    [HttpPut("{reviewId:int}/reject")]
    public async Task<IActionResult> RejectReview(int reviewId)
    {
        var result = await _reviewService.UpdateReviewStatusAsync(
            reviewId,
            "Rejected");

        if (!result)
        {
            return NotFound(new
            {
                message = "Review not found."
            });
        }

        return Ok(new
        {
            message = "Review rejected successfully."
        });
    }
}
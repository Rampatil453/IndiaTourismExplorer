using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;

namespace IndiaTourismExplorer.Application.Services;

public sealed class AdminFeedbackService : IAdminFeedbackService
{
    private readonly IAdminFeedbackRepository _repository;

    private static readonly string[] AllowedStatuses =
    [
        "Pending",
        "Reviewed",
        "Resolved",
        "Rejected"
    ];

    public AdminFeedbackService(IAdminFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<AdminFeedbackDto>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();

        return items.Select(MapToDto).ToList();
    }

    public async Task<AdminFeedbackDto?> GetByIdAsync(int feedbackId)
    {
        var item = await _repository.GetByIdAsync(feedbackId);

        return item is null ? null : MapToDto(item);
    }

    public async Task<bool> UpdateStatusAsync(int feedbackId, string status)
    {
        if (string.IsNullOrWhiteSpace(status))
        {
            return false;
        }

        var validStatus = AllowedStatuses.FirstOrDefault(
            candidate => string.Equals(
                candidate,
                status.Trim(),
                StringComparison.OrdinalIgnoreCase));

        if (validStatus is null)
        {
            return false;
        }

        var item = await _repository.GetByIdAsync(feedbackId);

        if (item is null)
        {
            return false;
        }

        item.Status = validStatus;
        await _repository.SaveChangesAsync();

        return true;
    }

    private static AdminFeedbackDto MapToDto(Feedback feedback)
    {
        return new AdminFeedbackDto
        {
            FeedbackId = feedback.FeedbackId,
            UserId = feedback.UserId,
            // If your Feedback entity's user navigation has a different name,
            // update this expression to match the existing entity.
            UserEmail = feedback.User?.Email,
            Message = feedback.Message,
            Status = feedback.Status,
            CreatedAt = feedback.CreatedAt
        };
    }
}
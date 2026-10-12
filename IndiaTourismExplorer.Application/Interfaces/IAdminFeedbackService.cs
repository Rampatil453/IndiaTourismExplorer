using IndiaTourismExplorer.Application.DTOs;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface IAdminFeedbackService
{
    Task<List<AdminFeedbackDto>> GetAllAsync();

    Task<AdminFeedbackDto?> GetByIdAsync(int feedbackId);

    Task<bool> UpdateStatusAsync(int feedbackId, string status);
}
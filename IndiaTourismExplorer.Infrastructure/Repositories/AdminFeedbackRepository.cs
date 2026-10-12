using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;
using IndiaTourismExplorer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IndiaTourismExplorer.Infrastructure.Repositories;

public sealed class AdminFeedbackRepository : IAdminFeedbackRepository
{
    private readonly TourismDbContext _context;

    public AdminFeedbackRepository(TourismDbContext context)
    {
        _context = context;
    }

    public async Task<List<Feedback>> GetAllAsync()
    {
        return await _context.Feedbacks
            .AsNoTracking()
            .OrderByDescending(feedback => feedback.CreatedAt)
            .ToListAsync();
    }

    public async Task<Feedback?> GetByIdAsync(int feedbackId)
    {
        return await _context.Feedbacks
            .FirstOrDefaultAsync(feedback => feedback.FeedbackId == feedbackId);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
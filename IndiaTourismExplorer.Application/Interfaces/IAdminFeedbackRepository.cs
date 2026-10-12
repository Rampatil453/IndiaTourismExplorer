using IndiaTourismExplorer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.Interfaces
{
    public interface IAdminFeedbackRepository
    {
        Task<List<Feedback>> GetAllAsync();
        Task<Feedback?> GetByIdAsync(int feedbackId);
        Task SaveChangesAsync();
    }
}

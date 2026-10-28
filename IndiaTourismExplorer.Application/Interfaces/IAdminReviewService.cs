using IndiaTourismExplorer.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.Interfaces
{
    public interface IAdminReviewService
    {
        Task<List<AdminReviewDto>> ListAsync(string? status);
        Task<AdminReviewDto?> GetAsync(int id);
        Task<AdminReviewDto?> SetStatusAsync(int id, UpdateReviewStatusDto request);
        Task<bool> DeleteAsync(int id);
    }
}

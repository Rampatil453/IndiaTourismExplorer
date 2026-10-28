using IndiaTourismExplorer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.Interfaces
{
    public interface IAdminReviewRepository
    {
        Task<List<Review>> ListAsync(string? status);
        Task<Review?> GetAsync(int id);
        Task SaveChangesAsync();
        void Delete(Review review);
    }
}

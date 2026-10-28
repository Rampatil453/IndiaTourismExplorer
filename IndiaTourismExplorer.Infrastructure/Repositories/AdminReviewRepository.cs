using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;
using IndiaTourismExplorer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Infrastructure.Repositories
{
    public sealed class AdminReviewRepository : IAdminReviewRepository
    {
        private readonly TourismDbContext _db;
        public AdminReviewRepository(TourismDbContext db)
        {
            _db = db;
        }
        public Task<List<Review>> ListAsync(string? status)
        {
            IQueryable<Review> query = _db.Reviews.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(status))
                query = query.Where(x => x.Status == status);
            return query.OrderByDescending(x => x.ReviewId).ToListAsync();
        }
        public Task<Review?> GetAsync(int id)
        {
            return _db.Reviews.FirstOrDefaultAsync(x => x.ReviewId == id);
        }
        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
        public void Delete(Review review)
        {
            _db.Reviews.Remove(review);

        }
    }
}

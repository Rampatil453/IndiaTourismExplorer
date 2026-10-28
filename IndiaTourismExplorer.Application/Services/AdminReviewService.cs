using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.Services
{
    public class AdminReviewService:IAdminReviewService
    {
        private readonly IAdminReviewRepository _repo;
        public AdminReviewService(IAdminReviewRepository repo)
        {
            _repo = repo;
        }
        private static AdminReviewDto Map(Review review) => new()
        {
            ReviewId = review.ReviewId,
            TouristPlaceId=review.TouristPlaceId,
            Rating=review.Rating,
            Status=review.Status,
        };
        private static bool Allowed(string? value)
        {
           return value is "Pending" or "Approved" or "Rejected";
        }
        public async Task<List<AdminReviewDto>> ListAsync(string? status)
        {
            if (!string.IsNullOrWhiteSpace(status) && !Allowed(status))
                throw new ArgumentException("Invalid review status.");
            return (await _repo.ListAsync(status)).Select(Map).ToList();
        }
        public async Task<AdminReviewDto?> GetAsync(int id)
        {
            var review = await _repo.GetAsync(id);
            return review is null ? null : Map(review);
        }
        public async Task<AdminReviewDto?> SetStatusAsync(int id, UpdateReviewStatusDto request)
        {
            if (request.Status is not ("Approved" or "Rejected"))
                throw new ArgumentException("Status must be Approved or Rejected.");
            var review = await _repo.GetAsync(id);
            if (review is null)
                return null;
            review.Status = request.Status;
            await _repo.SaveChangesAsync();
            return Map(review);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var review = await _repo.GetAsync(id);
            if (review is null)
                return false;
            _repo.Delete(review);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}

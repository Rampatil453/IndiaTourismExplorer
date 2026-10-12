using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;
using IndiaTourismExplorer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Infrastructure.Repositories
{
    public sealed class AdminTouristPlaceImageRepository:IAdminTouristPlaceImageRepository
    {
        private readonly TourismDbContext _context;
        public AdminTouristPlaceImageRepository(TourismDbContext context)
        {
            _context = context;
        }
        public async Task<List<TouristPlaceImage>> GetByTouristPlaceIdAsync(int touristPlaceId)
        {
            return await _context.TouristPlaceImages
                .AsNoTracking()
                .Where(image => image.TouristPlaceId == touristPlaceId)
                .OrderBy(image => image.DisplayOrder)
                .ToListAsync();
        }
        public async Task<TouristPlaceImage?> GetByIdAsync(int imageId)
        {
            return await _context.TouristPlaceImages
                .FirstOrDefaultAsync(image => image.ImageId == imageId);
        }
        public async Task<bool> TouristPlaceExistsAsync(int touristPlaceId)
        {
            return await _context.TouristPlaces
                .AnyAsync(place => place.TouristPlaceId == touristPlaceId);
        }
        public async Task AddAsync(TouristPlaceImage image)
        {
            await _context.TouristPlaceImages.AddAsync(image);
        }
        public Task DeleteAsync(TouristPlaceImage image)
        {
            _context.TouristPlaceImages.Remove(image);
            return Task.CompletedTask;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

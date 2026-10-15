using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;
using IndiaTourismExplorer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Infrastructure.Repositories
{
    public sealed class AdminTouristPlaceHighlightRepository:IAdminTouristPlaceHighlightRepository
    {
        private readonly TourismDbContext _context;
        public AdminTouristPlaceHighlightRepository(TourismDbContext context)
        {
            _context = context;
        }
        public Task<List<TouristPlaceHighlight>> GetByTouristPlaceIdAsync(int touristPlaceId)
        {
           return _context.TouristPlaceHighlights.AsNoTracking()
                  .Where(x => x.TouristPlaceId == touristPlaceId).ToListAsync();
        }
        public Task<TouristPlaceHighlight?> GetByIdAsync(int highlightId)
        {
          return  _context.TouristPlaceHighlights
                .FirstOrDefaultAsync(x => x.TouristPlaceHighlightId == highlightId);
        }
        public Task<bool> TouristPlaceExistsAsync(int touristPlaceId)
        {
           return _context.TouristPlaces.AnyAsync(x => x.TouristPlaceId == touristPlaceId);
        }
        public async Task AddAsync(TouristPlaceHighlight highlight)
        {
            await _context.TouristPlaceHighlights.AddAsync(highlight);
        }
        public Task DeleteAsync(TouristPlaceHighlight highlight)
        {
            _context.TouristPlaceHighlights.Remove(highlight);
            return Task.CompletedTask;
        }
        public Task SaveChangeAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}

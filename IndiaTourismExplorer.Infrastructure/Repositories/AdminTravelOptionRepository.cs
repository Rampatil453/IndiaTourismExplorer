using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;
using IndiaTourismExplorer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Infrastructure.Repositories
{
    public sealed class AdminTravelOptionRepository:IAdminTravelOptionRepository
    {
        private readonly TourismDbContext _context;
        public AdminTravelOptionRepository(TourismDbContext context)
        {
            _context = context;
        }
        public async Task<List<TravelOption>> GetByTouristPlaceIdAsync(int touristPlaceId)
        {
            return await _context.TravelOptions.AsNoTracking()
                .Where(x => x.TouristPlaceId == touristPlaceId).ToListAsync();
        }
        public async Task<TravelOption?> GetByIdAsync(int id)
        {
            return await _context.TravelOptions
                .FirstOrDefaultAsync(x => x.TravelOptionId == id);
        }
        public Task<bool> TouristPlaceExistsAsync(int touristPlaceId)
        {
            return _context.TouristPlaces.AnyAsync(x => x.TouristPlaceId == touristPlaceId);
        }
        public async Task AddAsync(TravelOption entity)
        {
           await _context.TravelOptions.AddAsync(entity);
        }
        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(TravelOption entity)
        {
            _context.TravelOptions.Update(entity);
        }
        public async Task DeleteAsync(TravelOption entity)
        {
            _context.TravelOptions.Remove(entity);
        }

        
    }
}

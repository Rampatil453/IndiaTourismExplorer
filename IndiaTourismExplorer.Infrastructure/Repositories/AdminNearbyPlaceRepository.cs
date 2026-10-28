using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;
using IndiaTourismExplorer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Infrastructure.Repositories
{
    public sealed class AdminNearbyPlaceRepository:IAdminNearbyPlaceRepository
    {
        private readonly TourismDbContext _db;
        public AdminNearbyPlaceRepository(TourismDbContext db)
        {
            _db = db;
        }
        public Task<List<NearbyPlace>> GetByTouristPlaceIdAsync(int touristPlaceId)
        {
           return _db.NearbyPlaces.AsNoTracking()
                .Where(x => x.TouristPlaceId == touristPlaceId)
                .ToListAsync();
        }
        public Task<NearbyPlace?> GetByAsync(int id)
        {
            return _db.NearbyPlaces.FirstOrDefaultAsync(x => x.NearbyPlaceId == id);
        }
        public Task<bool> TouristPlaceExistsAsync(int id)
        {
            return _db.TouristPlaceCategories.AnyAsync(x => x.TouristPlaceId == id);
        }
        public Task<bool> LinkExistsAsync(int touristPlaceId, int nearbyTouristPlcaeId,int? excludeId=null)
        {
            return _db.NearbyPlaces.AnyAsync(x => x.TouristPlaceId == touristPlaceId &&
            x.NearbyTouristPlaceId == nearbyTouristPlcaeId &&
            (!excludeId.HasValue || x.NearbyTouristPlaceId != excludeId.Value));
        }
        public async Task AddAsync(NearbyPlace entity)
        {
           await _db.NearbyPlaces.AddAsync(entity);
        }
        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
        public void Remove(NearbyPlace entity)
        {
            _db.NearbyPlaces.Remove(entity);
        }

       
    }
}

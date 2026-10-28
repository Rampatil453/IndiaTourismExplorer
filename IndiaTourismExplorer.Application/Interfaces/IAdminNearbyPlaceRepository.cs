using IndiaTourismExplorer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.Interfaces
{
    public interface IAdminNearbyPlaceRepository
    {
        Task<List<NearbyPlace>> GetByTouristPlaceIdAsync(int touristPlaceId);
        Task<NearbyPlace?> GetByAsync(int id);
        Task<bool> TouristPlaceExistsAsync(int id);
        Task<bool> LinkExistsAsync(int touristOlaceId, int nearbyTouristPlaceId, int? exclaudeId = null);
        Task AddAsync(NearbyPlace entity);
        Task SaveChangesAsync();
        void Remove(NearbyPlace entity);
    }
}

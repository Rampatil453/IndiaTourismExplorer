using IndiaTourismExplorer.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.Interfaces
{
    public interface IAdminNearbyPlaceService
    {
        Task<List<AdminNearbyPlaceDto>> GetByPlaceAsync(int placeId);
        Task<AdminNearbyPlaceDto?> GetAsync(int id);
        Task<AdminNearbyPlaceDto> CreateAsync(CreateNearbyPlaceDto request);
        Task<AdminNearbyPlaceDto?> UpdateAsync(int id, CreateNearbyPlaceDto request);
        Task<bool> DeleteAsync(int id);
    }
}

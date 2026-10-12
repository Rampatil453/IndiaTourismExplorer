using IndiaTourismExplorer.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.Interfaces
{
    public interface IAdminTouristPlaceImageService
    {
        Task<List<AdminTouristPlaceImageDto>> GetByTouristPlaceIdAsync(int touristPlaceId);
        Task<AdminTouristPlaceImageDto?> GetByIdAsync(int imageId);
        Task<AdminTouristPlaceImageDto?> CreateAsync(AdminTouristPlaceImageDto request);
        Task<bool> UpdateAsync(int imageId, AdminTouristPlaceImageDto request);
        Task<bool> DeleteAsync(int imageId);
    }
}

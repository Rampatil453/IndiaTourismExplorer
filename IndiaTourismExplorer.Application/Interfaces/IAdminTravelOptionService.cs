using IndiaTourismExplorer.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.Interfaces
{
    public interface IAdminTravelOptionService
    {
        Task<List<AdminTravelOptionDto>> GetByTouristPlaceIdAsync(int touristPlaceId);
        Task<AdminTravelOptionDto?> GetByIdAsync(int id);
        Task<AdminTravelOptionDto> CreateAsync(AdminTravelOptionDto dto);
        Task<AdminTravelOptionDto?> UpdateAsync(int id, AdminTravelOptionDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

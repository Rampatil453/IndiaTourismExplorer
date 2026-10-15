using IndiaTourismExplorer.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.Interfaces
{
    public interface IAdminVisitingInformationService
    {
        Task<List<AdminVisitingInformationDto>> GetByTouristPlaceIdAsync(int touristPlaceId);
        Task<AdminVisitingInformationDto?> GetByIdAsync(int id);
        Task<AdminVisitingInformationDto> CreateAsync(AdminVisitingInformationDto dto);
        Task<bool> UpdateAsync(int id, AdminVisitingInformationDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

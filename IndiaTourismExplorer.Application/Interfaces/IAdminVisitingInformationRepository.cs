using IndiaTourismExplorer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.Interfaces
{
    public interface IAdminVisitingInformationRepository
    {
        Task<List<VisitingInformation>> GetByTouristPlaceIdAsync(int touristPlaceId);
        Task<VisitingInformation?> GetByIdAsync(int id);
        Task<bool> TouristPlaceExistsAsync(int touristPlaceId);
        Task<VisitingInformation> AddAsync(VisitingInformation entity);
        Task UpdateAsync(VisitingInformation entity);
        Task<bool> DeleteAsync(int id);
        
        
    }
}

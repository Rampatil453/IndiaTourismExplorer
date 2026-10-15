using IndiaTourismExplorer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.Interfaces
{
    public interface IAdminTravelOptionRepository
    {
        Task<List<TravelOption>> GetByTouristPlaceIdAsync(int touristPlaceId);
        Task<TravelOption?> GetByIdAsync(int id);
        Task<bool> TouristPlaceExistsAsync(int touristPlaceid);
        Task AddAsync(TravelOption entity);
        Task UpdateAsync(TravelOption entity);
        Task DeleteAsync(TravelOption entity);
        Task SaveChangesAsync();
    }
}

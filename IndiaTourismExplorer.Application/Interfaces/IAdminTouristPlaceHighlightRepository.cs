using IndiaTourismExplorer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.Interfaces
{
    public interface IAdminTouristPlaceHighlightRepository
    {
        Task<List<TouristPlaceHighlight>> GetByTouristPlaceIdAsync(int touristPlaceId);
        Task<TouristPlaceHighlight?> GetByIdAsync(int highlightId);
        Task<bool> TouristPlaceExistsAsync(int touristPlaceId);
        Task AddAsync(TouristPlaceHighlight highlight);
        Task DeleteAsync(TouristPlaceHighlight highlight);
        Task SaveChangeAsync();
    }
}

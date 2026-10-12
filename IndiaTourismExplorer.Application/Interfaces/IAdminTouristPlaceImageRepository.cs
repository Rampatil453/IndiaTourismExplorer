using IndiaTourismExplorer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.Interfaces
{
    public interface IAdminTouristPlaceImageRepository
    {
        Task<List<TouristPlaceImage>> GetByTouristPlaceIdAsync(int touristPlaceId);
        Task<TouristPlaceImage?> GetByIdAsync(int imageId);
        Task<bool> TouristPlaceExistsAsync(int touristPlaceId);
        Task AddAsync(TouristPlaceImage image);
        Task DeleteAsync(TouristPlaceImage image);
        Task SaveChangesAsync();
    }
}

using IndiaTourismExplorer.Application.DTOs;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface IAdminTouristPlaceHighlightService
{
    Task<List<AdminTouristPlaceHighlightDto>> GetByTouristPlaceIdAsync(int touristPlaceId);
    Task<AdminTouristPlaceHighlightDto?> GetByIdAsync(int highlightId);
    Task<AdminTouristPlaceHighlightDto?> CreateAsync(AdminTouristPlaceHighlightDto dto);
    Task<AdminTouristPlaceHighlightDto?> UpdateAsync(int highlightId, AdminTouristPlaceHighlightDto dto);
    Task<bool> DeleteAsync(int highlightId);
}
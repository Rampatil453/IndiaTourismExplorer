using IndiaTourismExplorer.Application.DTOs;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface ITouristPlaceService
{
    Task<List<TouristPlaceDto>> GetByLocationIdAsync(
        int locationId);

    Task<TouristPlaceDto?> GetByIdAsync(int id);

    Task<List<TouristPlaceDto>> GetFeaturedAsync();

    Task<TouristPlaceDetailsDto?> GetDetailsByIdAsync(int id);
    Task<List<TouristPlaceDto>> GetByCategoryIdAsync(int categoryId);

    Task<bool> CreateAsync(AdminTouristPlaceDto dto);

    Task<bool> UpdateAsync(int id, AdminTouristPlaceDto dto);

    Task<bool> DeleteAsync(int id);
}
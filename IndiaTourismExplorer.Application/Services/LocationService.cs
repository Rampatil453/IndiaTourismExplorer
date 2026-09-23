using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;

namespace IndiaTourismExplorer.Application.Services;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;

    public LocationService(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<List<LocationDto>> GetByStateIdAsync(int stateId)
    {
        var locations = await _locationRepository
            .GetByStateIdAsync(stateId);

        return locations.Select(x => new LocationDto
        {
            LocationId = x.LocationId,
            StateId = x.StateId,
            Name = x.Name,
            Type = x.Type,
            Description = x.Description,
            ImageUrl = x.ImageUrl,
            Latitude = x.Latitude,
            Longitude = x.Longitude
        }).ToList();
    }

    public async Task<LocationDto?> GetByIdAsync(int id)
    {
        var location = await _locationRepository
            .GetByIdAsync(id);

        if (location == null)
        {
            return null;
        }

        return new LocationDto
        {
            LocationId = location.LocationId,
            StateId = location.StateId,
            Name = location.Name,
            Type = location.Type,
            Description = location.Description,
            ImageUrl = location.ImageUrl,
            Latitude = location.Latitude,
            Longitude = location.Longitude
        };
    }
    public async Task<bool> CreateAsync(AdminLocationDto dto)
    {
        var location = new Domain.Entities.Location
        {
            StateId = dto.StateId,
            Name = dto.Name,
            Type = dto.Type,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            IsActive = dto.IsActive,
            CreatedAt = DateTime.UtcNow
        };
        await _locationRepository.AddAsync(location);
        await _locationRepository.SaveChangesAsync();
        return true;
    }
    public async Task<bool> UpdateAsync(
    int id,
    AdminLocationDto dto)
    {
        var location = await _locationRepository
            .GetByIdForAdminAsync(id);
        if (location == null)
        {
            return false;
        }
        location.StateId = dto.StateId;
        location.Name = dto.Name;
        location.Type = dto.Type;
        location.Description = dto.Description;
        location.ImageUrl = dto.ImageUrl;
        location.Latitude = dto.Latitude;
        location.Longitude = dto.Longitude;
        location.IsActive = dto.IsActive;
        location.UpdatedAt = DateTime.UtcNow;
        _locationRepository.Update(location);
        await _locationRepository.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var location = await _locationRepository
            .GetByIdForAdminAsync(id);

        if (location == null)
        {
            return false;
        }

        var hasTouristPlaces =
            await _locationRepository.HasTouristPlacesAsync(id);

        if (hasTouristPlaces)
        {
            throw new InvalidOperationException(
                "Cannot delete this location because tourist places exist."
            );
        }

        _locationRepository.Remove(location);

        await _locationRepository.SaveChangesAsync();

        return true;
    }
}
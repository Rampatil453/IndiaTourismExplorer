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
}
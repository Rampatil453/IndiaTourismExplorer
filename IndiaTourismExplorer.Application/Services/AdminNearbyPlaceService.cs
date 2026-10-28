using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;

namespace IndiaTourismExplorer.Application.Services;

public sealed class AdminNearbyPlaceService : IAdminNearbyPlaceService
{
    private readonly IAdminNearbyPlaceRepository _repo;
    public AdminNearbyPlaceService(IAdminNearbyPlaceRepository repo) => _repo = repo;

    private static AdminNearbyPlaceDto Map(NearbyPlace x) => new()
    {
        NearbyPlaceId = x.NearbyPlaceId,
        TouristPlaceId = x.TouristPlaceId,
        NearbyTouristPlaceId = x.NearbyTouristPlaceId
    };

    private async Task ValidateAsync(CreateNearbyPlaceDto request, int? excludeId = null)
    {
        if (request.TouristPlaceId <= 0 || request.NearbyTouristPlaceId <= 0)
            throw new ArgumentException("Both tourist place IDs must be positive.");
        if (request.TouristPlaceId == request.NearbyTouristPlaceId)
            throw new ArgumentException("A tourist place cannot be nearby itself.");
        if (!await _repo.TouristPlaceExistsAsync(request.TouristPlaceId) ||
            !await _repo.TouristPlaceExistsAsync(request.NearbyTouristPlaceId))
            throw new ArgumentException("One or both tourist places do not exist.");
        if (await _repo.LinkExistsAsync(request.TouristPlaceId, request.NearbyTouristPlaceId, excludeId))
            throw new ArgumentException("This nearby-place link already exists.");
    }

    public async Task<List<AdminNearbyPlaceDto>> GetByPlaceAsync(int placeId)
    {
        if (!await _repo.TouristPlaceExistsAsync(placeId))
            throw new KeyNotFoundException("Tourist place not found.");
        return (await _repo.GetByTouristPlaceIdAsync(placeId)).Select(Map).ToList();
    }

    public async Task<AdminNearbyPlaceDto?> GetAsync(int id)
    {
        var entity = await _repo.GetByAsync(id);
        return entity is null ? null : Map(entity);
    }

    public async Task<AdminNearbyPlaceDto> CreateAsync(CreateNearbyPlaceDto request)
    {
        await ValidateAsync(request);
        var entity = new NearbyPlace
        {
            TouristPlaceId = request.TouristPlaceId,
            NearbyTouristPlaceId = request.NearbyTouristPlaceId
        };
        await _repo.AddAsync(entity);
        await _repo.SaveChangesAsync();
        return Map(entity);
    }

    public async Task<AdminNearbyPlaceDto?> UpdateAsync(int id, CreateNearbyPlaceDto request)
    {
        var entity = await _repo.GetByAsync(id);
        if (entity is null) return null;
        await ValidateAsync(request, id);
        entity.TouristPlaceId = request.TouristPlaceId;
        entity.NearbyTouristPlaceId = request.NearbyTouristPlaceId;
        await _repo.SaveChangesAsync();
        return Map(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repo.GetByAsync(id);
        if (entity is null) return false;
        _repo.Remove(entity);
        await _repo.SaveChangesAsync();
        return true;
    }

}
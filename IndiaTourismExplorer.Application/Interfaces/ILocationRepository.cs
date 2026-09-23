using IndiaTourismExplorer.Domain.Entities;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface ILocationRepository
{
    Task<List<Location>> GetByStateIdAsync(int stateId);

    Task<Location?> GetByIdAsync(int id);

    Task<Location?> GetByIdForAdminAsync(int id);
    Task AddAsync(Location location);
    void Update(Location location);
    void Remove(Location location);
    Task<bool> HasTouristPlacesAsync(int locationId);
    Task SaveChangesAsync();
}
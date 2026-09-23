using IndiaTourismExplorer.Application.DTOs;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface ILocationService
{
    Task<List<LocationDto>> GetByStateIdAsync(int stateId);

    Task<LocationDto?> GetByIdAsync(int id);

    Task<bool> CreateAsync(AdminLocationDto dto);
    Task<bool> UpdateAsync(int id, AdminLocationDto dto);
    Task<bool> DeleteAsync(int id);
}
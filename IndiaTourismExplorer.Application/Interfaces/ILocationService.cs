using IndiaTourismExplorer.Application.DTOs;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface ILocationService
{
    Task<List<LocationDto>> GetByStateIdAsync(int stateId);

    Task<LocationDto?> GetByIdAsync(int id);
}
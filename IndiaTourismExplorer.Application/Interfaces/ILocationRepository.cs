using IndiaTourismExplorer.Domain.Entities;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface ILocationRepository
{
    Task<List<Location>> GetByStateIdAsync(int stateId);

    Task<Location?> GetByIdAsync(int id);
}
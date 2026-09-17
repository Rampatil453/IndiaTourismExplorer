using IndiaTourismExplorer.Application.DTOs;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface IStateService
{
    Task<List<StateDto>> GetAllAsync();

    Task<StateDto?> GetByIdAsync(int id);
}
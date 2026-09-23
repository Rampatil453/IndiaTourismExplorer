using IndiaTourismExplorer.Application.DTOs;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface IStateService
{
    Task<List<StateDto>> GetAllAsync();

    Task<StateDto?> GetByIdAsync(int id);

    Task<bool> CreateAsync(AdminStateDto dto);

    Task<bool> UpdateAsync(int id, AdminStateDto dto);

    Task<bool> DeleteAsync(int id);
}
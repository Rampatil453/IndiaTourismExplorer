using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;

namespace IndiaTourismExplorer.Application.Services;

public class StateService : IStateService
{
    private readonly IStateRepository _stateRepository;

    public StateService(IStateRepository stateRepository)
    {
        _stateRepository = stateRepository;
    }

    public async Task<List<StateDto>> GetAllAsync()
    {
        var states = await _stateRepository.GetAllAsync();

        return states.Select(x => new StateDto
        {
            StateId = x.StateId,
            Name = x.Name,
            Code = x.Code,
            Description = x.Description,
            ImageUrl = x.ImageUrl
        }).ToList();
    }

    public async Task<StateDto?> GetByIdAsync(int id)
    {
        var state = await _stateRepository.GetByIdAsync(id);

        if (state == null)
        {
            return null;
        }

        return new StateDto
        {
            StateId = state.StateId,
            Name = state.Name,
            Code = state.Code,
            Description = state.Description,
            ImageUrl = state.ImageUrl
        };
    }
    public async Task<bool> CreateAsync(AdminStateDto dto)
    {
        var state = new Domain.Entities.State
        {
            Name = dto.Name,
            Code = dto.Code,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            IsActive = dto.IsActive,
            CreatedAt = DateTime.UtcNow
        };

        await _stateRepository.AddAsync(state);
        await _stateRepository.SaveChangesAsync();

        return true;
    }
    public async Task<bool> UpdateAsync(
    int id,
    AdminStateDto dto)
    {
        var state = await _stateRepository
            .GetByIdForAdminAsync(id);

        if (state == null)
        {
            return false;
        }

        state.Name = dto.Name;
        state.Code = dto.Code;
        state.Description = dto.Description;
        state.ImageUrl = dto.ImageUrl;
        state.IsActive = dto.IsActive;
        state.UpdatedAt = DateTime.UtcNow;

        _stateRepository.Update(state);
        await _stateRepository.SaveChangesAsync();

        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var state = await _stateRepository
            .GetByIdForAdminAsync(id);

        if (state == null)
        {
            return false;
        }

        _stateRepository.Delete(state);

        await _stateRepository.SaveChangesAsync();

        return true;
    }

}
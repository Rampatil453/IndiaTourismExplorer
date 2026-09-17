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
}
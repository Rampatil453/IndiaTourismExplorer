using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTourismExplorer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatesController : ControllerBase
{
    private readonly IStateService _stateService;

    public StatesController(IStateService stateService)
    {
        _stateService = stateService;
    }

    [HttpGet]
    public async Task<ActionResult<List<StateDto>>> GetAll()
    {
        var states = await _stateService.GetAllAsync();

        return Ok(states);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<StateDto>> GetById(int id)
    {
        var state = await _stateService.GetByIdAsync(id);

        if (state == null)
        {
            return NotFound(new
            {
                message = "State not found."
            });
        }

        return Ok(state);
    }
}
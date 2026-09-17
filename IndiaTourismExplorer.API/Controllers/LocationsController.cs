using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTourismExplorer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationsController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet("state/{stateId:int}")]
    public async Task<ActionResult<List<LocationDto>>> GetByStateId(
        int stateId)
    {
        var locations = await _locationService
            .GetByStateIdAsync(stateId);

        return Ok(locations);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<LocationDto>> GetById(int id)
    {
        var location = await _locationService
            .GetByIdAsync(id);

        if (location == null)
        {
            return NotFound(new
            {
                message = "Location not found."
            });
        }

        return Ok(location);
    }
}
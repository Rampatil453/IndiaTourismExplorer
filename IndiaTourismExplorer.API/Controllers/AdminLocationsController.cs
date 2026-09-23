using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTourismExplorer.API.Controllers;

[Route("api/admin/locations")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdminLocationsController : ControllerBase
{
    private readonly ILocationService _locationService;

    public AdminLocationsController(
        ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        AdminLocationDto dto)
    {
        var result = await _locationService.CreateAsync(dto);

        if (!result)
        {
            return BadRequest("Location creation failed.");
        }

        return Ok("Location created successfully.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        AdminLocationDto dto)
    {
        var result = await _locationService.UpdateAsync(id, dto);

        if (!result)
        {
            return NotFound("Location not found.");
        }

        return Ok("Location updated successfully.");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _locationService.DeleteAsync(id);

            if (!result)
            {
                return NotFound("Location not found.");
            }

            return Ok("Location deleted successfully.");
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new
            {
                message = ex.Message
            });
        }
    }
}
using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTourismExplorer.API.Controllers;

[ApiController]
[Route("api/admin/touristplaces")]
[Authorize(Roles = "Admin")]
public class AdminTouristPlacesController : ControllerBase
{
    private readonly ITouristPlaceService _service;

    public AdminTouristPlacesController(
        ITouristPlaceService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        AdminTouristPlaceDto dto)
    {
        var result = await _service.CreateAsync(dto);

        if (!result)
        {
            return BadRequest(new
            {
                message = "Failed to create tourist place."
            });
        }

        return Ok(new
        {
            message = "Tourist place created successfully."
        });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        AdminTouristPlaceDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);

        if (!result)
        {
            return NotFound(new
            {
                message = "Tourist place not found."
            });
        }

        return Ok(new
        {
            message = "Tourist place updated successfully."
        });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);

        if (!result)
        {
            return NotFound(new
            {
                message = "Tourist place not found."
            });
        }

        return Ok(new
        {
            message = "Tourist place deleted successfully."
        });
    }
}
using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTourismExplorer.API.Controllers;

[Route("api/admin/states")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdminStatesController : ControllerBase
{
    private readonly IStateService _stateService;

    public AdminStatesController(
        IStateService stateService)
    {
        _stateService = stateService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        AdminStateDto dto)
    {
        var result = await _stateService.CreateAsync(dto);

        if (!result)
        {
            return BadRequest("State creation failed.");
        }

        return Ok("State created successfully.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        AdminStateDto dto)
    {
        var result = await _stateService.UpdateAsync(id, dto);

        if (!result)
        {
            return NotFound("State not found.");
        }

        return Ok("State updated successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _stateService.DeleteAsync(id);

        if (!result)
        {
            return NotFound("State not found.");
        }

        return Ok("State deleted successfully.");
    }
}
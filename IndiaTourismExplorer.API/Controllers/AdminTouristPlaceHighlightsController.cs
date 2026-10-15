using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTourismExplorer.API.Controllers;

[ApiController]
[Route("api/admin/tourist-place-highlights")]
[Authorize(Roles = "Admin")]
public sealed class AdminTouristPlaceHighlightsController : ControllerBase
{
    private readonly IAdminTouristPlaceHighlightService _service;

    public AdminTouristPlaceHighlightsController(
        IAdminTouristPlaceHighlightService service)
    {
        _service = service;
    }

    [HttpGet("by-place/{touristPlaceId:int}")]
    public async Task<IActionResult> GetByPlace(int touristPlaceId)
    {
        if (touristPlaceId <= 0)
            return BadRequest(new { message = "Tourist place ID must be positive." });

        var items = await _service.GetByTouristPlaceIdAsync(touristPlaceId);
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (id <= 0)
            return BadRequest(new { message = "Highlight ID must be positive." });

        var item = await _service.GetByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] AdminTouristPlaceHighlightDto dto)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var created = await _service.CreateAsync(dto);
        if (created is null)
            return BadRequest(new { message = "Tourist place was not found or input was invalid." });

        return CreatedAtAction(nameof(GetById),
            new { id = created.HighlightId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id, [FromBody] AdminTouristPlaceHighlightDto dto)
    {
        if (id <= 0)
            return BadRequest(new { message = "Highlight ID must be positive." });

        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var updated = await _service.UpdateAsync(id, dto);
        return updated is null ? NotFound(
            new { message = "Highlight or tourist place was not found." }) : Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
            return BadRequest(new { message = "Highlight ID must be positive." });

        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
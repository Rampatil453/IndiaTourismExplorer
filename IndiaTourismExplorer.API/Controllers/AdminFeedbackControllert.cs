using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTourismExplorer.API.Controllers;

[ApiController]
[Route("api/admin/feedback")]
[Authorize(Roles = "Admin")]
public sealed class AdminFeedbackController : ControllerBase
{
    private readonly IAdminFeedbackService _service;

    public AdminFeedbackController(IAdminFeedbackService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<AdminFeedbackDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<AdminFeedbackDto>>> GetAll()
    {
        var feedback = await _service.GetAllAsync();
        return Ok(feedback);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(AdminFeedbackDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AdminFeedbackDto>> GetById(int id)
    {
        var feedback = await _service.GetByIdAsync(id);

        if (feedback is null)
        {
            return NotFound(new { message = "Feedback was not found." });
        }

        return Ok(feedback);
    }

    [HttpPut("{id:int}/status")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateStatus(
        int id,
        [FromBody] UpdateFeedbackStatusRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Status))
        {
            return BadRequest(new { message = "Status is required." });
        }

        var updated = await _service.UpdateStatusAsync(id, request.Status);

        if (!updated)
        {
            var existing = await _service.GetByIdAsync(id);

            if (existing is null)
            {
                return NotFound(new { message = "Feedback was not found." });
            }

            return BadRequest(new { message = "The supplied feedback status is invalid." });
        }

        return NoContent();
    }
}

public sealed class UpdateFeedbackStatusRequest
{
    public string Status { get; set; } = string.Empty;
}
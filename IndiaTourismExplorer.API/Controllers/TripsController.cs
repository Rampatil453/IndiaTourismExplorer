using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IndiaTourismExplorer.API.Controllers
{
    [Route("api/trips")]
    [ApiController]
    [Authorize]
    public sealed class TripsController : ControllerBase
    {
        private readonly ITripService _service;
        public TripsController(ITripService service)
        {
            _service = service;
        }
        private string? UserId =>
            User.FindFirstValue(ClaimTypes.NameIdentifier) ??
            User.FindFirstValue("sub");
        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            return UserId is { } uid ? Ok(await _service.MineAsync(uid)) : Unauthorized();
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            if (UserId is not { } uid)
                return Unauthorized();
            var t = await _service.GetMineAsync(id, uid);
            return t is null ? NotFound() : Ok(t);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TripUpsertDto dto)
        {
            if (UserId is not { } uid)
                return Unauthorized();
            try
            {
                var result = await _service.CreateAsync(uid, dto);
                return CreatedAtAction(nameof(Get), new { id = result.TripId }, result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TripUpsertDto dto)
        {
            if (UserId is not { } uid)
                return Unauthorized();
            try
            {
                var result = await _service.UpdateAsync(id, uid, dto);
                return result is null ? NotFound() : Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (UserId is not { } uid)
                return Unauthorized();
            return await _service.DeleteMineAsync(id, uid) ? NoContent() : NotFound();
        }
   }
}

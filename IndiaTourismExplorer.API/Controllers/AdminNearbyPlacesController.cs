using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTourismExplorer.API.Controllers
{
    [Route("api/admin/nearby-places")]
    [Authorize(Roles ="Admin")]
    [ApiController]
    public sealed class AdminNearbyPlacesController : ControllerBase
    {
        private readonly IAdminNearbyPlaceService _service;
        public AdminNearbyPlacesController(IAdminNearbyPlaceService service)
        {
            _service = service;
        }
        [HttpGet("by-place/{touristPlaceId:int}")]
        public async Task<IActionResult> ByPlace(int touristPlaceId)
        {
            try
            {
                return Ok(await _service.GetByPlaceAsync(touristPlaceId));
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });

            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetAsync(id);
            return result is null ? NotFound() : Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateNearbyPlaceDto request)
        {
            try
            {
                var result = await _service.CreateAsync(request);
                return CreatedAtAction(nameof(Get), new { id = result.NearbyPlaceId },result);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody]CreateNearbyPlaceDto request)
        {
            try
            {
                var result = await _service.UpdateAsync(id, request);
                return result is null ? NotFound() : Ok(result);
            }
            catch(ArgumentException ex)
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
        return await _service.DeleteAsync(id) ? NoContent() : NotFound();
        }
    }
}


using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTourismExplorer.API.Controllers
{
    [Route("api/admin/visiting-information")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminVisitingInformationController : ControllerBase
    {
        private readonly IAdminVisitingInformationService _service;
        public AdminVisitingInformationController(IAdminVisitingInformationService service)
        {
            _service = service;
        }
        [HttpGet("by-place/{touristPlaceId:int}")]
        public async Task<IActionResult> GetByPlace(int touristPlaceId)
        {
            if (touristPlaceId <= 0)
                return BadRequest("touristPlaceId must be greater than zero.");
            return Ok(await _service.GetByTouristPlaceIdAsync(touristPlaceId));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("id must be greater than zero.");
            var result = await _service.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdminVisitingInformationDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.VisitingInformationId }, created);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] AdminVisitingInformationDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return updated ? NotFound() : Ok(updated);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("id must be greater than zero.");
               
            return await _service.DeleteAsync(id) ? NoContent() : NotFound();
        }
    }
}

using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTourismExplorer.API.Controllers
{
    [Route("api/admin/review")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminReviewController : ControllerBase
    {
        private readonly IAdminReviewService _service;
        public AdminReviewController(IAdminReviewService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] string? status)
        {
            try
            {
                return Ok(await _service.ListAsync(status));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var review = await _service.GetAsync(id);
            return review is null ? NotFound() : Ok(review);
        }
        [HttpPatch("{id:int}/status")]
        public async Task<IActionResult> SetStaus(int id, [FromBody] UpdateReviewStatusDto request)
        {
            try
            {
                var review = await _service.SetStatusAsync(id,request);
                return review is null ? NotFound() : Ok(review);
            }catch(ArgumentException ex)
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

using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTourismExplorer.API.Controllers
{
    [Route("api/admin/trips")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AdminTripsController : ControllerBase
    {
        private readonly ITripService _service;
        public AdminTripsController(ITripService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _service.AllAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var t = await _service.GetAnyAsync(id);
            return t is null ? NotFound() : Ok(t);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _service.DeleteAnyAsync(id) ? NoContent() : NotFound();
        }

    }
}

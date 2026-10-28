using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTourismExplorer.API.Controllers
{
    [Route("api/admin/favorites")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AdminFavoritesController : ControllerBase
    {
        private readonly IFavoriteService _service;
        public AdminFavoritesController(IFavoriteService service)
        {
            _service = service;
        }
        [HttpGet("summary")]
        public async Task<IActionResult> Summary()
        {
            return Ok(await _service.GetSummaryAsync());
        }
    }
}

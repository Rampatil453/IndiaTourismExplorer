using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTourismExplorer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public sealed class AdminTouristPlaceImagesController : ControllerBase
    {
        private readonly IAdminTouristPlaceImageService _service;
        public AdminTouristPlaceImagesController(IAdminTouristPlaceImageService service)
        {
            _service = service;
        }
        [HttpGet("by-place/{touristPlaceId:int}")]
        public async Task<ActionResult<List<AdminTouristPlaceImageDto>>> GetByPlace(int touristPlaceId)
        {
            if (touristPlaceId <= 0)
            {
                return BadRequest(new
                {
                    message = "TouristPlaceId must be greater than zero."
                });
            }
            return Ok(await _service.GetByTouristPlaceIdAsync(touristPlaceId));
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AdminTouristPlaceImageDto>> GetById(int id)
        {
            var image = await _service.GetByIdAsync(id);
            return image is null ? NotFound(new { message = "Tourist place image was not found." }) : Ok(image);
        }
        [HttpPost]
        public async Task<ActionResult<AdminTouristPlaceImageDto>> Create([FromBody] AdminTouristPlaceImageDto request)
        {
            if(string.IsNullOrWhiteSpace(request.ImageUrl))
               return BadRequest(new
                {
                    message = "ImageUrl is required."
                });
            var created = await _service.CreateAsync(request);
            if (created is null)
                return BadRequest(new
                {
                    message = "The specified tourist place does not exist."
                });
            return CreatedAtAction(nameof(GetById), new
            {
                id = created.TouristPlaceImageId
            }, created);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] AdminTouristPlaceImageDto request)
        {
            if (id <= 0)
                return BadRequest(new
                {
                    message = "Image ID must be greater than zero."
                });
            if (string.IsNullOrWhiteSpace(request.ImageUrl))
                return BadRequest(new
                {
                    message = "ImageUrl is reduired."
                });
            var updated = await _service.UpdateAsync(id, request);
            if(!updated)
            {
                var current = await _service.GetByIdAsync(id);
                return current is null ? NotFound(new
                {
                    message = "Tourist place image was not found."
                }) : BadRequest(new
                {
                    message = "The specified tourist place not exist."
                });
            }
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest(new
                {
                    message = "Image Id must be greater than zero."
                });
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound(new
            {
                message = "Tourist place image was not found."
            });
        }
    }
}

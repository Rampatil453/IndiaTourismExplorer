using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTourismExplorer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TouristPlacesController : ControllerBase
{
    private readonly ITouristPlaceService _service;

    public TouristPlacesController(
        ITouristPlaceService service)
    {
        _service = service;
    }

    [HttpGet("location/{locationId:int}")]
    public async Task<ActionResult<List<TouristPlaceDto>>>
        GetByLocationId(int locationId)
    {
        var places = await _service
            .GetByLocationIdAsync(locationId);

        return Ok(places);
    }
    [HttpGet("details/{id:int}")]
    public async Task<ActionResult<TouristPlaceDetailsDto>> GetDetailsById(int id)
    {
        var place = await _service.GetDetailsByIdAsync(id);

        if (place == null)
        {
            return NotFound(new { message = "Tourist place not found." });
        }

        return Ok(place);
    }

    [HttpGet("category/{categoryId:int}")]
    public async Task<ActionResult<List<TouristPlaceDto>>> GetByCategoryId(int categoryId)
    {
        var places = await _service.GetByCategoryIdAsync(categoryId);

        return Ok(places);
    }
    [HttpGet("featured")]
    public async Task<ActionResult<List<TouristPlaceDto>>> GetFeatured()
    {
        var places = await _service.GetFeaturedAsync();

        return Ok(places);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TouristPlaceDto>>
        GetById(int id)
    {
        var place = await _service.GetByIdAsync(id);

        if (place == null)
        {
            return NotFound(new
            {
                message = "Tourist place not found."
            });
        }

        return Ok(place);
    }
}
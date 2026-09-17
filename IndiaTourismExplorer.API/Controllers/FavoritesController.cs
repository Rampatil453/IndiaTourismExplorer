using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IndiaTourismExplorer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FavoritesController : ControllerBase
{
    private readonly IFavoriteService _favoriteService;

    public FavoritesController(IFavoriteService favoriteService)
    {
        _favoriteService = favoriteService;
    }

    [HttpPost("{touristPlaceId:int}")]
    public async Task<IActionResult> AddFavorite(int touristPlaceId)
    {
        var userId = User.FindFirstValue(
            ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return Unauthorized();
        }

        var added = await _favoriteService.AddFavoriteAsync(
            userId,
            touristPlaceId);

        if (!added)
        {
            return Conflict(new
            {
                message = "This place is already in your favorites."
            });
        }

        return Ok(new
        {
            message = "Tourist place added to favorites."
        });
    }

    [HttpDelete("{touristPlaceId:int}")]
    public async Task<IActionResult> RemoveFavorite(int touristPlaceId)
    {
        var userId = User.FindFirstValue(
            ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return Unauthorized();
        }

        var removed = await _favoriteService.RemoveFavoriteAsync(
            userId,
            touristPlaceId);

        if (!removed)
        {
            return NotFound(new
            {
                message = "Favorite not found."
            });
        }

        return Ok(new
        {
            message = "Tourist place removed from favorites."
        });
    }

    [HttpGet]
    public async Task<ActionResult<List<FavoriteDto>>> GetMyFavorites()
    {
        var userId = User.FindFirstValue(
            ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return Unauthorized();
        }

        var favorites =
            await _favoriteService.GetMyFavoritesAsync(userId);

        return Ok(favorites);
    }
    [HttpGet("{touristPlaceId:int}/status")]
    public async Task<IActionResult> GetFavoriteStatus(int touristPlaceId)
    {
        var userId = User.FindFirstValue(
            ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return Unauthorized();
        }

        var isFavorite =
            await _favoriteService.IsFavoriteAsync(
                userId,
                touristPlaceId);

        return Ok(new
        {
            touristPlaceId,
            isFavorite
        });
    }
}
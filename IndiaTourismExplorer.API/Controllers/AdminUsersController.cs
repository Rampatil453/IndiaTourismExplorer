using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTourismExplorer.API.Controllers;

[Route("api/admin/users")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdminUsersController : ControllerBase
{
    private readonly IAdminUserService _userService;

    public AdminUsersController(
        IAdminUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();

        return Ok(users);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetById(string userId)
    {
        var user = await _userService.GetByIdAsync(userId);

        if (user == null)
        {
            return NotFound("User not found.");
        }

        return Ok(user);
    }
}
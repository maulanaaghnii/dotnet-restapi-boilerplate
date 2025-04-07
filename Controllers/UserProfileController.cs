using Microsoft.AspNetCore.Mvc;
using UserProfileApi.Models;
using UserProfileApi.Services;
using UserProfileApi.DTOs;

namespace UserProfileApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private readonly IUserProfileService _service;
    private readonly ILogger<UserProfileController> _logger;

    public UserProfileController(IUserProfileService service, ILogger<UserProfileController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("GET /api/userprofile");
        return Ok(await _service.GetAll());
    }

    [HttpGet("{uuid}")]
    public async Task<IActionResult> GetById(Guid uuid)
    {
        _logger.LogInformation("GET /api/userprofile/{uuid}", uuid);
        var result = await _service.GetById(uuid);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserProfileDto dto)
    {
        _logger.LogInformation("POST /api/userprofile");
        var user = new UserProfile
        {
            Username = dto.Username,
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            BirthDate = dto.BirthDate
        };
        await _service.Create(user);
        return CreatedAtAction(nameof(GetById), new { uuid = user.Uuid }, user);
    }

    [HttpPut("{uuid}")]
    public async Task<IActionResult> Update(Guid uuid, [FromBody] UserProfile user)
    {
        _logger.LogInformation("PUT /api/userprofile/{uuid}", uuid);
        var existing = await _service.GetById(uuid);
        if (existing == null) return NotFound();
        user.Uuid = uuid;
        await _service.Update(user);
        return NoContent();
    }

    [HttpDelete("{uuid}")]
    public async Task<IActionResult> Delete(Guid uuid)
    {
        _logger.LogInformation("DELETE /api/userprofile/{uuid}", uuid);
        await _service.Delete(uuid);
        return NoContent();
    }
}

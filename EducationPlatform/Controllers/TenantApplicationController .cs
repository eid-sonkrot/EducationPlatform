using Domain.IService;
using EducationPlatform.DTO;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TenantApplicationController : ControllerBase
{
    private readonly ITenantService _TenantService;

    public TenantApplicationController(ITenantService ITenantService)
    {
        _TenantService = ITenantService;
    }

    [HttpPost("apply")]
    public async Task<IActionResult> ApplyForTenant([FromBody] TenantApplicationDTO applicationDto)
    {
        // Validate email domain
        if (!IsValidUniversityEmail(applicationDto.OfficialEmail))
        {
            return BadRequest("Invalid email domain.");
        }

        // Generate secure key
        var secureKey = _TenantService.GenerateSecureKey();

        // Send secure key via email (implement email sending logic)
        await _TenantService.SendSecureKeyAsync(applicationDto.OfficialEmail, secureKey);

        return Ok("Secure key sent to your official email.");
    }

    private bool IsValidUniversityEmail(string email)
    {
        // Implement your logic to validate the email domain
        return email.EndsWith("@ppu.edu.ps"); // Example for Palestine Polytechnic University
    }
}

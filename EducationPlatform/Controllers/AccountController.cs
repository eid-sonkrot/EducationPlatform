using Domain.IService;
using EducationPlatform.DTO;
using EducationPlatform.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITenantService _tenantService;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITenantService tenantService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tenantService = tenantService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
    {
        // Check if tenant exists
        if (!await _tenantService.TenantExists(registerDto.TenantId))
        {
            return BadRequest("Invalid tenant.");
        }

        // Create the user
        var user = new ApplicationUser
        {
            UserName = registerDto.Email,
            Email = registerDto.Email,
            TenantId = registerDto.TenantId
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (result.Succeeded)
        {
            // Assign role (Admin or Student)
            await _userManager.AddToRoleAsync(user, registerDto.Role);

            return Ok(new { Message = "User registered successfully." });
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
    {
        var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, loginDto.RememberMe, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            return Ok(new { Message = "Login successful." });
        }

        if (result.IsLockedOut)
        {
            return Unauthorized(new { Message = "Account is locked out." });
        }

        return Unauthorized(new { Message = "Invalid login attempt." });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok(new { Message = "Logout successful." });
    }
}

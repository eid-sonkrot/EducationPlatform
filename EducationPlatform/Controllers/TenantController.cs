using Microsoft.AspNetCore.Mvc;
using EducationPlatform.DTO;
using Domain.IService;
using AutoMapper;
using Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class TenantController : ControllerBase
{
    private readonly ITenantService _tenantService;
    private readonly IMapper _mapper;
    public TenantController(ITenantService tenantService , IMapper mapper)
    {
        _tenantService = tenantService;
        _mapper = mapper;
    }

    [HttpPost("verify")]
    public async Task<IActionResult> VerifyAndCreateTenant([FromBody] TenantVerificationDTO verificationDto)
    {
        // Verify the secure key
        if (!(await _tenantService.VerifySecureKey(verificationDto.UniversityName, verificationDto.SecureKey)))
        {
            return Unauthorized("Invalid secure key.");
        }
        // Create tenant
        await _tenantService.CreateTenantAsync(_mapper.Map<TenantVerification>(verificationDto));
        return Ok("Tenant is created Successfly");
    }
}

using Microsoft.AspNetCore.Identity;
using System;
namespace EducationPlatform.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public Guid TenantId { get; set; }
    }
}

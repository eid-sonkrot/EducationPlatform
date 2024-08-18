using Domain.Models;

namespace Domain.IService
{
    public interface ITenantService
    {
        public string GenerateSecureKey();
        public Task SendSecureKeyAsync(string email, string secureKey);
        public Task<bool> VerifySecureKey(string universityName, string secureKey);
        public Task CreateTenantAsync(TenantVerification? tenantVerification);
        public Task<bool> TenantExists(Guid tenantId);
    }
}
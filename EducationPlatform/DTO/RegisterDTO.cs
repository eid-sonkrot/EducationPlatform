namespace EducationPlatform.DTO
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }  // "Admin" or "Student"
        public Guid TenantId { get; set; }
    }
}

namespace EducationPlatform.DTO
{
    public class VideoCreatorDto
    {
        public string Content { get; set; }
        public Guid StudentId { get; set; }
        public Guid TenantId { get; set; }
    }
}
namespace Domain.Models
{
    public class Video
    {
        public string Content { get; set; }
        public Guid StudentId { get; set; }
        public Guid TenantId { get; set; }
    }
}
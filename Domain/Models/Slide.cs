namespace Domain.Models
{
    public class Slide
    {
        public string Content { get; set; }
        public Guid StudentId { get; set; }
        public Guid TenantId { get; set; }
    }
}

namespace Domain.Models
{
    public class Design
    {
        public string Content { get; set; }
        public Guid StudentId { get; set; }
        public Guid TenantId { get; set; }
    }
}
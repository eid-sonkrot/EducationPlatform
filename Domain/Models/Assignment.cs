namespace Domain.Models
{
    public class Assignment
    {
        public Guid AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public List<Question> Questions { get; set; }
        public Guid TeacherId { get; set; }
        public Guid TenantId { get; set; }
    }
}

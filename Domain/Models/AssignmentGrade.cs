namespace Domain.Models
{
    public class AssignmentGrade
    {
        public Guid AssignmentId { get; set; }
        public Guid StudentId { get; set; }
        public Guid TenantId { get; set; }
        public double Grade { get; set; }
    }
}
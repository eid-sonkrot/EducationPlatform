namespace EducationPlatform.DTO
{
    public class SaveAssignmentRequestDto
    {
        public List<Guid> SelectedQuestionIds { get; set; }
        public string AssignmentName { get; set; }
        public Guid TeacherId { get; set; }
        public Guid TenantId { get; set; }
    }
}

namespace EducationPlatform.DTO
{
    public class QuestionDto
    {
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }
    }
}

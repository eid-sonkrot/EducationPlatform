namespace EducationPlatform.DTO
{
    public class GenerateQuestionsRequestDto
    {
        public int NumberOfQuestions { get; set; }
        public string BookOrPdfName { get; set; }
        public string ChapterName { get; set; }
    }
}

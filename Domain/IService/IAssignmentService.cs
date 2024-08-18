using Domain.Models;

namespace Domain.IService
{
    public interface IAssignmentService
    {
        Task<List<Question>> GenerateQuestionsAsync(int numberOfQuestions, string bookOrPdfName, string chapterName);
        Task<Assignment> SaveAssignmentAsync(List<Guid> selectedQuestionIds, string assignmentName, Guid teacherId, Guid tenantId);
    }
}

using Doamin.IRepository;
using Domain.IService;
using Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace Domain.Service
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly OpenAIService _openAIService;
        private List<Question> _questionBank = new List<Question>
        {
            // Sample question bank
            new Question { QuestionId = Guid.NewGuid(), QuestionText = "What is ASP.NET?", Options = new List<string> { "A framework", "A language", "A database", "An OS" }, CorrectAnswer = "A framework" },
            new Question { QuestionId = Guid.NewGuid(), QuestionText = "Explain MVC pattern.", Options = new List<string> { "Model-View-Controller", "Model-View-Code", "Monitor-View-Controller", "Model-Virtual-Controller" }, CorrectAnswer = "Model-View-Controller" },
        };

        public AssignmentService(IAssignmentRepository assignmentRepository, OpenAIService openAIService)
        {
            _assignmentRepository = assignmentRepository;
            _openAIService = openAIService;
        }

        public async Task<List<Question>> GenerateQuestionsAsync(int numberOfQuestions, string bookOrPdfName, string chapterName)
        {
            var question = "can you plz provide me with " + numberOfQuestions.ToString() + " from book name : " + bookOrPdfName;
            if(chapterName!=null)
            {
                question += "from chapter " + chapterName;
            }
            question += "and put it in json form as List of Dictonary<string,string>";
            var answer = await _openAIService.AskQuestionAsync(question);
            return JsonConvert.DeserializeObject<List<Question>>(answer)
                   ??new List<Question>();
        }

        public async Task<Assignment> SaveAssignmentAsync(List<Guid> selectedQuestionIds, string assignmentName, Guid teacherId, Guid tenantId)
        {
            var selectedQuestions = _questionBank.Where(q => selectedQuestionIds.Contains(q.QuestionId)).ToList();

            var assignment = new Assignment
            {
                AssignmentId = Guid.NewGuid(),
                AssignmentName = assignmentName,
                Questions = selectedQuestions,
                TeacherId = teacherId,
                TenantId = tenantId
            };

            await _assignmentRepository.AddAsync(assignment);

            return assignment;
        }
    }
}

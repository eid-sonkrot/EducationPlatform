using AutoMapper;
using Domain.IService;
using EducationPlatform.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.Controllers
{
    [ApiController]
    [Route("api/assignments")]
    //[Authorize(Roles = "Teacher")]  // Restrict access to users with the "Teacher" role
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        private readonly IMapper _mapper;

        public AssignmentController(IAssignmentService assignmentService, IMapper mapper)
        {
            _assignmentService = assignmentService;
            _mapper = mapper;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateQuestions([FromBody] GenerateQuestionsRequestDto requestDto)
        {
            var questions = await _assignmentService.GenerateQuestionsAsync(requestDto.NumberOfQuestions, requestDto.BookOrPdfName, requestDto.ChapterName);
            var responseDto = new GenerateQuestionsResponseDto
            {
                Questions = _mapper.Map<List<QuestionDto>>(questions)
            };
            return Ok(responseDto);
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveAssignment([FromBody] SaveAssignmentRequestDto requestDto)
        {
            var assignment = await _assignmentService.SaveAssignmentAsync(requestDto.SelectedQuestionIds, requestDto.AssignmentName, requestDto.TeacherId, requestDto.TenantId);
            return Ok(assignment);
        }

        [HttpPost("regenerate")]
        public async Task<IActionResult> RegenerateQuestions([FromBody] GenerateQuestionsRequestDto requestDto)
        {
            var questions = await _assignmentService.GenerateQuestionsAsync(requestDto.NumberOfQuestions, requestDto.BookOrPdfName, requestDto.ChapterName);
            var responseDto = new GenerateQuestionsResponseDto
            {
                Questions = _mapper.Map<List<QuestionDto>>(questions)
            };
            return Ok(responseDto);
        }
    }
}

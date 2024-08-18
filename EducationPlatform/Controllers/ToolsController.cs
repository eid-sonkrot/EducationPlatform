using AutoMapper;
using Domain.Models;
using EducationPlatform.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.Controllers
{
    [ApiController]
    [Route("api/tools")]
    public class ToolsController : ControllerBase
    {
        private readonly IToolsService _toolsService;
        private readonly IMapper _mapper;

        public ToolsController(IToolsService toolsService, IMapper mapper)
        {
            _toolsService = toolsService;
            _mapper = mapper;
        }

        [HttpPost("slide-maker")]
        public async Task<IActionResult> CreateSlides([FromBody] SlideMakerDto slideMakerDto)
        {
            var slide = _mapper.Map<Slide>(slideMakerDto);
            var result = await _toolsService.GenerateSlidesAsync(slide);
            return Ok(result);
        }

        [HttpPost("video-creator")]
        public async Task<IActionResult> CreateVideo([FromBody] VideoCreatorDto videoCreatorDto)
        {
            var video = _mapper.Map<Video>(videoCreatorDto);
            var result = await _toolsService.CreateVideoAsync(video);
            return Ok(result);
        }

        [HttpPost("design-tool")]
        public async Task<IActionResult> CreateDesign([FromBody] DesignToolDto designToolDto)
        {
            var design = _mapper.Map<Design>(designToolDto);
            var result = await _toolsService.CreateDesignAsync(design);
            return Ok(result);
        }

        [HttpPost("auto-grade")]
        public async Task<IActionResult> AutoGrade([FromBody] AutoGradeDto autoGradeDto)
        {
            var grade = _mapper.Map<AssignmentGrade>(autoGradeDto);
            var result = await _toolsService.AutoGradeAsync(grade);
            return Ok(result);
        }
    }
}

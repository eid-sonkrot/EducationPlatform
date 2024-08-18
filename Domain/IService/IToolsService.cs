using Domain.Models;
public interface IToolsService
{
    Task<Slide> GenerateSlidesAsync(Slide slide);
    Task<Video> CreateVideoAsync(Video video);
    Task<Design> CreateDesignAsync(Design design);
    Task<AssignmentGrade> AutoGradeAsync(AssignmentGrade grade);
}
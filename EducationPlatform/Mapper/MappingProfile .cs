using AutoMapper;
using Domain.Models;
using EducationPlatform.DTO;

namespace EducationPlatform.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TenantVerificationDTO, TenantVerification>();
            CreateMap<TenantVerification, TenantVerificationDTO>();
            CreateMap<SlideMakerDto, Slide>();
            CreateMap<VideoCreatorDto, Video>();
            CreateMap<DesignToolDto, Design>();
            CreateMap<AutoGradeDto, AssignmentGrade>();
        }
    }
}

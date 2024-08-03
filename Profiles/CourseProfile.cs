using AutoMapper;
using ExaminationSystem.DTO.Course;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Course;

namespace ExaminationSystem.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile() 
        {
            CreateMap<CourseViewModel, CourseDTO>().ReverseMap();
            CreateMap<CourseCreateViewModel, CourseCreateDTO>().ReverseMap();

            CreateMap<CourseDTO, Course>().ReverseMap();
            CreateMap<CourseCreateDTO, Course>().ReverseMap();
        }
    }
}

using AutoMapper;
using ExaminationSystem.DTO.Department;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Department;

namespace ExaminationSystem.Profiles
{
    public class DepartmentProfile: Profile
    {
        public DepartmentProfile() 
        {
            CreateMap<DepartmentViewModel, DepartmentDTO>().ReverseMap();
            CreateMap<DepartmentCreateViewModel, DepartmentCreateDTO>()
                .ForMember(dst => dst.CourseIDs, opt => opt.Ignore())
                .ForMember(dst => dst.InstructorIDs, opt => opt.Ignore())
                .ForMember(dst => dst.StudentIDs, opt => opt.Ignore());

            CreateMap<DepartmentDTO, Department>().ReverseMap();
            CreateMap<DepartmentCreateDTO, Department>()
                .ForMember(dst => dst.Courses, opt => opt.Ignore())
                .ForMember(dst => dst.Instructors, opt => opt.Ignore())
                .ForMember(dst => dst.Students, opt => opt.Ignore());
        }
    }
}

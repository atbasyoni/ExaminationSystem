using AutoMapper;
using ExaminationSystem.DTO.Exam;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Exam;

namespace ExaminationSystem.Profiles
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<ExamViewModel, ExamDTO>().ReverseMap();
            CreateMap<ExamCreateViewModel, ExamCreateDTO>().ReverseMap();

            CreateMap<ExamDTO, Exam>().ReverseMap();
            CreateMap<ExamCreateDTO, Exam>().ReverseMap();

            CreateMap<ExamStudentCreateViewModel, ExamStudentCreateDTO>().ReverseMap();
            CreateMap<ExamStudentViewModel, ExamStudentDTO>().ReverseMap();

            CreateMap<ExamStudentCreateDTO, ExamStudent>();
            CreateMap<ExamStudentDTO, ExamStudent>();

            CreateMap<ExamAnswerDTO, ExamAnswer>();
        }
    }
}
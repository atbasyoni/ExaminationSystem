using AutoMapper;
using ExaminationSystem.DTO.Exam;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Exam;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExaminationSystem.Profiles
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<ExamCreateViewModel, ExamCreateDTO>();

            CreateMap<ExamCreateDTO, Exam>().ReverseMap();

            CreateMap<Exam, ExamDTO>()
                .ForMember(dst => dst.ExamID, opt => opt.MapFrom(src => src.ID)) // > 1000 ? src.ID : src.ID - 500));
                                                                                 //.ForMember(dst => dst.StartDate, opt => opt.Ignore())
                .ForMember(dst => dst.NumberOfQuestions, opt => opt.MapFrom(src => src.ExamQuestions.Count))
                .ForMember(dst => dst.FirstQuestion, opt =>
                    opt.MapFrom(src => src.ExamQuestions.Select(x => x.Question.Text).FirstOrDefault()));


            CreateMap<ExamDTO, ExamViewModel>();
        }
    }
}
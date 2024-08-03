using AutoMapper;
using ExaminationSystem.DTO.Question;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Exam;
using ExaminationSystem.ViewModels.Question;

namespace ExaminationSystem.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile() 
        {
            CreateMap<QuestionViewModel, QuestionDTO>().ReverseMap();
            CreateMap<QuestionCreateViewModel, QuestionCreateDTO>().ReverseMap();

            CreateMap<QuestionDTO, Question>().ReverseMap();
            CreateMap<QuestionCreateDTO, Question>().ReverseMap();
        }
    }
}

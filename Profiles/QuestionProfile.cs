using AutoMapper;
using ExaminationSystem.DTO.Choice;
using ExaminationSystem.DTO.Question;
using ExaminationSystem.Enums;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Exam;
using ExaminationSystem.ViewModels.Question;

namespace ExaminationSystem.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile() 
        {
            CreateMap<QuestionCreateViewModel, QuestionCreateDTO>().ReverseMap();

            CreateMap<QuestionViewModel, QuestionDTO>().ReverseMap();

            CreateMap<QuestionCreateDTO, QuestionCreateViewModel>()
            .ReverseMap();

            CreateMap<QuestionDTO, Question>()
                .ForMember(dest => dest.ExamQuestions, opt => opt.Ignore())
                .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(src => Enum.Parse<DifficultyLevel>(src.Difficulty)))
                .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.ChoiceDTOs.Select(dto => new Choice
                {
                    Id = dto.Id,
                    Text = dto.Text,
                    IsCorrect = dto.IsCorrect
                }).ToHashSet()))
                .ReverseMap()
                .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(src => src.Difficulty.ToString()))
                .ForMember(dest => dest.ChoiceDTOs, opt => opt.MapFrom(src => src.Choices.Select(choice => new ChoiceDTO
                {
                    Id = choice.Id,
                    Text = choice.Text,
                    IsCorrect = choice.IsCorrect
                }).ToList()));

            CreateMap<QuestionCreateDTO, Question>()
                .ForMember(dest => dest.ExamQuestions, opt => opt.Ignore())
                .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(src => Enum.Parse<DifficultyLevel>(src.Difficulty)))
                .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.ChoiceDTOs.Select(dto => new Choice
                {
                    Text = dto.Text,
                    IsCorrect = dto.IsCorrect
                }).ToHashSet()));
        }
    }
}

using AutoMapper;
using ExaminationSystem.DTO.Choice;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Choices;

namespace ExaminationSystem.Profiles
{
    public class ChoiceProfile : Profile
    {
        public ChoiceProfile() 
        {
            CreateMap<ChoiceViewModel, ChoiceDTO>().ReverseMap();
            CreateMap<ChoiceCreateViewModel, ChoiceCreateDTO>().ReverseMap();

            CreateMap<ChoiceDTO, Choice>().ReverseMap();
            CreateMap<ChoiceCreateDTO, Choice>().ReverseMap();
        }
    }
}

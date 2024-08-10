using AutoMapper;
using ExaminationSystem.DTO.Accounts;
using ExaminationSystem.Models;

namespace ExaminationSystem.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile() 
        {
            CreateMap<RegisterRequestDTO, User>().ReverseMap();
        }
    }
}

using ExaminationSystem.DTO.Choice;

namespace ExaminationSystem.Mediators.Choices
{
    public interface IChoiceMediator
    {
        Task<ChoiceDTO> GetById(int id);
        Task<int> AddChoice(ChoiceCreateDTO choiceDTO);
        Task EditChoice(ChoiceDTO choiceDTO);
        Task DeleteChoice(int id);
    }
}

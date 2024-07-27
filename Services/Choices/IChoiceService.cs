using ExaminationSystem.DTO.Choice;

namespace ExaminationSystem.Services.Choices
{
    public interface IChoiceService
    {
        void AddRange(int questionID, List<ChoiceDTO> choices);
    }
}

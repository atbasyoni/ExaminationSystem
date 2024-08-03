using ExaminationSystem.DTO.Choice;

namespace ExaminationSystem.Services.Choices
{
    public interface IChoiceService
    {
        void AddRange(int questionID, List<ChoiceDTO> choices);
        int Add(ChoiceCreateDTO choiceDTO);
        IEnumerable<ChoiceDTO> GetAll();
        ChoiceDTO GetByID(int id);
        void Update(ChoiceDTO choiceDTO);
        void Delete(int id);
    }
}

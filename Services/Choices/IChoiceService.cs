using ExaminationSystem.DTO.Choice;
using ExaminationSystem.Models;

namespace ExaminationSystem.Services.Choices
{
    public interface IChoiceService
    {
        void AddRange(int questionID, List<ChoiceCreateDTO> choices);
        int Add(ChoiceCreateDTO choiceDTO);
        IEnumerable<ChoiceDTO> GetAll();
        ChoiceDTO GetByID(int id);
        void Update(ChoiceDTO choiceDTO);
        void Delete(int id);
        void DeleteRange(IEnumerable<Choice> choices);
    }
}

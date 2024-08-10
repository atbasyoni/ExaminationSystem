using ExaminationSystem.DTO.Choice;
using ExaminationSystem.Models;

namespace ExaminationSystem.Services.Choices
{
    public interface IChoiceService
    {
        Task<IEnumerable<ChoiceDTO>> GetAll();
        Task<ChoiceDTO> GetByID(int id);
        Task<int> Add(ChoiceCreateDTO choiceDTO);
        Task AddRange(int questionID, List<ChoiceCreateDTO> choices);
        Task Update(ChoiceDTO choiceDTO);
        Task Delete(int id);
        Task DeleteRange(IEnumerable<Choice> choices);
    }
}

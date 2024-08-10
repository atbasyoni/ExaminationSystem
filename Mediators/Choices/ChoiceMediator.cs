using ExaminationSystem.DTO.Choice;
using ExaminationSystem.Services.Choices;

namespace ExaminationSystem.Mediators.Choices
{
    public class ChoiceMediator : IChoiceMediator
    {

        private readonly IChoiceService _choiceService;

        public ChoiceMediator(IChoiceService choiceService)
        {
            _choiceService = choiceService;
        }

        public async Task<int> AddChoice(ChoiceCreateDTO choiceDTO)
        {
            int choiceId = await _choiceService.Add(choiceDTO);
            return choiceId;
        }

        public async Task EditChoice(ChoiceDTO choiceDTO)
        {
            await _choiceService.Update(choiceDTO);
        }


        public async Task DeleteChoice(int id)
        {
            var Choice = await _choiceService.GetByID(id);

            if (Choice != null)
            {
                await _choiceService.Delete(id);
            }
        }

        public async Task<ChoiceDTO> GetById(int id)
        {
            return await _choiceService.GetByID(id);
        }
    }
}

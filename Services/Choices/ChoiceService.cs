using ExaminationSystem.DTO.Choice;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;

namespace ExaminationSystem.Services.Choices
{
    public class ChoiceService : IChoiceService
    {
        private readonly IRepository<Choice> choiceRepository;

        public ChoiceService(IRepository<Choice> choiceRepository)
        {
            this.choiceRepository = choiceRepository;
        }

        public void AddRange(int questionID, List<ChoiceDTO> choices)
        {
            foreach (ChoiceDTO choice in choices)
            {
                choiceRepository.Add(
                    new Choice
                    {
                        QuestionID = questionID,
                        Text = choice.Text,
                        IsCorrect = choice.IsCorrect,
                    }
                );
            }

            choiceRepository.SaveChanges();
        }
    }
}

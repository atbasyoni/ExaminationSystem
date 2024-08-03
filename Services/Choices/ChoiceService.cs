using AutoMapper.QueryableExtensions;
using ExaminationSystem.DTO.Choice;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;

namespace ExaminationSystem.Services.Choices
{
    public class ChoiceService : IChoiceService
    {
        private readonly IRepository<Choice> _choiceRepository;
        private readonly IRepository<Question> _questionRepository;

        public ChoiceService(IRepository<Choice> choiceRepository, IRepository<Question> questionRepository)
        {
            _choiceRepository = choiceRepository;
            _questionRepository = questionRepository;
        }

        public int Add(ChoiceCreateDTO choiceDTO)
        {
            var choice = choiceDTO.MapOne<Choice>();

            choice = _choiceRepository.Add(choice);

            var question = _questionRepository.GetWithTrackinByID(choice.QuestionID);
            question.Choices.Add(choice);
            _questionRepository.Update(question);

            return choice.Id;
        }

        public void AddRange(int questionID, List<ChoiceDTO> choices)
        {
            foreach (ChoiceDTO choice in choices)
            {
                _choiceRepository.Add(
                    new Choice
                    {
                        QuestionID = questionID,
                        Text = choice.Text,
                        IsCorrect = choice.IsCorrect,
                    }
                );
            }
        }

        public void Delete(int id)
        {
            var choice = _choiceRepository.GetByID(id);
            _choiceRepository.Delete(choice);
        }

        public IEnumerable<ChoiceDTO> GetAll()
        {
            return _choiceRepository.GetAll().AsQueryable().Map<ChoiceDTO>();
        }

        public ChoiceDTO GetByID(int id)
        {
            return _choiceRepository.GetByID(id).MapOne<ChoiceDTO>();
        }

        public void Update(ChoiceDTO choiceDTO)
        {
            var choice = _choiceRepository.GetWithTrackinByID(choiceDTO.Id);

            _choiceRepository.Update(choice);
        }
    }
}

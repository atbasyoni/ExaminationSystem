using AutoMapper.QueryableExtensions;
using ExaminationSystem.DTO.Choice;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories.Bases;

namespace ExaminationSystem.Services.Choices
{
    public class ChoiceService : IChoiceService
    {
        private readonly IRepository<Choice> _choiceRepository;

        public ChoiceService(IRepository<Choice> choiceRepository)
        {
            _choiceRepository = choiceRepository;
        }

        public int Add(ChoiceCreateDTO choiceDTO)
        {
            var choice = choiceDTO.MapOne<Choice>();
            choice = _choiceRepository.Add(choice);

            _choiceRepository.SaveChanges();

            return choice.Id;
        }

        public void AddRange(int questionID, List<ChoiceCreateDTO> choices)
        {
            foreach (ChoiceCreateDTO choice in choices)
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

            _choiceRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            var choice = _choiceRepository.GetByID(id);
            _choiceRepository.Delete(choice);
            _choiceRepository.SaveChanges();
        }
        
        public void DeleteRange(IEnumerable<Choice> choices)
        {
            _choiceRepository.DeleteRange(choices);
            _choiceRepository.SaveChanges();
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
            _choiceRepository.SaveChanges();
        }
    }
}

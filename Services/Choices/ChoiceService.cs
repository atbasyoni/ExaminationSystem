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

        public async Task<int> Add(ChoiceCreateDTO choiceDTO)
        {
            var choice = choiceDTO.MapOne<Choice>();
            choice = await _choiceRepository.AddAsync(choice);

            await _choiceRepository.SaveChangesAsync();

            return choice.Id;
        }

        public async Task AddRange(int questionID, List<ChoiceCreateDTO> choices)
        {
            foreach (ChoiceCreateDTO choice in choices)
            {
                await _choiceRepository.AddAsync(
                    new Choice
                    {
                        QuestionID = questionID,
                        Text = choice.Text,
                        IsCorrect = choice.IsCorrect,
                    }
                );
            }

            await _choiceRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var choice = await _choiceRepository.GetByIDAsync(id);
            _choiceRepository.Delete(choice);
            await _choiceRepository.SaveChangesAsync();
        }
        
        public async Task DeleteRange(IEnumerable<Choice> choices)
        {
            _choiceRepository.DeleteRange(choices);
            await _choiceRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ChoiceDTO>> GetAll()
        {
            return (await _choiceRepository.GetAllAsync()).AsQueryable().Map<ChoiceDTO>();
        }

        public async Task<ChoiceDTO> GetByID(int id)
        {
            return (await _choiceRepository.GetByIDAsync(id)).MapOne<ChoiceDTO>();
        }

        public async Task Update(ChoiceDTO choiceDTO)
        {
            var choice = await _choiceRepository.GetWithTrackingByIDAsync(choiceDTO.Id);
            _choiceRepository.Update(choice);
            await _choiceRepository.SaveChangesAsync();
        }
    }
}

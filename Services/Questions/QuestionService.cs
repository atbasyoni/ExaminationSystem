using ExaminationSystem.DTO.Question;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories.Bases;

namespace ExaminationSystem.Services.Questions
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> _questionRepository;

        public QuestionService(IRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<int> Add(QuestionCreateDTO questionCreateDTO)
        {
            var question = questionCreateDTO.MapOne<Question>();
            
            question = await _questionRepository.AddAsync(question);
            await _questionRepository.SaveChangesAsync();

            return question.Id;
        }

        public async Task Delete(int id)
        {
            var question = await _questionRepository.GetWithTrackingByIDAsync(id);
            _questionRepository.Delete(question);
            await _questionRepository.SaveChangesAsync();
        }

        public async Task<QuestionDTO> GetByID(int id)
        {
            var question = await _questionRepository.GetByIDAsync(id);
            return question.MapOne<QuestionDTO>();
        }

        public async Task Update(QuestionDTO questionDTO)
        {
            var question = questionDTO.MapOne<Question>();
            _questionRepository.Update(question);
            await _questionRepository.SaveChangesAsync();
        }
    }
}

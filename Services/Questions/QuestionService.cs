using ExaminationSystem.DTO.Question;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;

namespace ExaminationSystem.Services.Questions
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> _questionRepository;

        public QuestionService(IRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public int Add(QuestionCreateDTO questionCreateDTO)
        {
            var question = questionCreateDTO.MapOne<Question>();
            
            question = _questionRepository.Add(question);

            return question.Id;
        }

        public void Delete(int id)
        {
            var question = _questionRepository.GetByID(id);
            _questionRepository.Delete(question);
        }

        public QuestionDTO GetByID(int id)
        {
            var question = _questionRepository.GetByID(id);
            return question.MapOne<QuestionDTO>();
        }

        public void Update(QuestionDTO questionDTO)
        {
            var question = questionDTO.MapOne<Question>();
            _questionRepository.Update(question);
        }
    }
}

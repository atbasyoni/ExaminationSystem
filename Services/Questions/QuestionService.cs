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

        public int Add(QuestionCreateDTO questionCreateDTO)
        {
            var question = questionCreateDTO.MapOne<Question>();
            
            question = _questionRepository.Add(question);
            _questionRepository.SaveChanges();

            return question.Id;
        }

        public void Delete(int id)
        {
            var question = _questionRepository.GetWithTrackinByID(id);
            _questionRepository.Delete(question);
            _questionRepository.SaveChanges();
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
            _questionRepository.SaveChanges();
        }
    }
}

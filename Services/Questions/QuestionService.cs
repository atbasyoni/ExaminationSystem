using ExaminationSystem.DTO.Question;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.Services.Choices;

namespace ExaminationSystem.Services.Questions
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> questionRepository;
        private readonly IChoiceService choiceService;


        public int Add(QuestionCreateDTO questionCreateDTO)
        {
            var question = questionCreateDTO.MapOne<Question>();
            
            question = questionRepository.Add(question);
            
            questionRepository.SaveChanges();

            choiceService.AddRange(question.ID, questionCreateDTO.Choics);

            return question.ID;
        }

        public void Delete(int id)
        {
            var question = questionRepository.GetByID(id);
            questionRepository.Delete(question);
            questionRepository.SaveChanges();
        }

        public QuestionDTO GetByID(int id)
        {
            var question = questionRepository.GetByID(id);
            return question.MapOne<QuestionDTO>();
        }

        public void Update(QuestionDTO questionDTO)
        {
            var question = questionDTO.MapOne<Question>();
            questionRepository.Update(question);
            questionRepository.SaveChanges();
        }
    }
}

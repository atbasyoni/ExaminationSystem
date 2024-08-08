using ExaminationSystem.DTO.Question;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories.Bases;
using ExaminationSystem.Services.Choices;
using ExaminationSystem.Services.Exams;
using ExaminationSystem.Services.Questions;
using ExaminationSystem.ViewModels.Exam;
using ExaminationSystem.ViewModels.Question;

namespace ExaminationSystem.Mediators
{
    public class QuestionMediator : IQuestionMediator
    {
        private readonly IQuestionService _questionService;
        private readonly IExamQuestionService _examQuestionService;

        public QuestionMediator(IQuestionService questionService, IExamQuestionService examQuestionService)
        {
            _questionService = questionService;
            _examQuestionService = examQuestionService;
        }

        public int AddQuestion(QuestionCreateDTO questionDTO)
        {
            int questionId = _questionService.Add(questionDTO);
            return questionId;
        }

        public void EditQuestion(QuestionDTO questionDTO)
        {
            _questionService.Update(questionDTO);
        }


        public void DeleteQuestion(int id)
        {
            var Question = _questionService.GetByID(id);

            if (Question != null)
            {
                _questionService.Delete(id);

                var examQuestions = _examQuestionService.Get(eq => eq.QuestionID == id);

                if (examQuestions != null) 
                {
                    _examQuestionService.DeleteRange(examQuestions);
                }
            }
        }

        public QuestionDTO GetById(int id)
        {
            return _questionService.GetByID(id);
        }
    }
}

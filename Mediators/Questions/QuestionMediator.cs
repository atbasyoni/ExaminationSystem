using ExaminationSystem.DTO.Question;
using ExaminationSystem.Services.Exams;
using ExaminationSystem.Services.Questions;

namespace ExaminationSystem.Mediators.Questions
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

        public async Task<int> AddQuestion(QuestionCreateDTO questionDTO)
        {
            int questionId = await _questionService.Add(questionDTO);
            return questionId;
        }

        public async Task EditQuestion(QuestionDTO questionDTO)
        {
            await _questionService.Update(questionDTO);
        }


        public async Task DeleteQuestion(int id)
        {
            var Question = await _questionService.GetByID(id);

            if (Question != null)
            {
                await _questionService.Delete(id);

                var examQuestions = await _examQuestionService.Get(eq => eq.QuestionID == id);

                if (examQuestions != null)
                {
                    await _examQuestionService.DeleteRange(examQuestions);
                }
            }
        }

        public async Task<QuestionDTO> GetById(int id)
        {
            return await _questionService.GetByID(id);
        }
    }
}

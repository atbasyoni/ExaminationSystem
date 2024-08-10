using ExaminationSystem.DTO.Question;
using ExaminationSystem.Helpers;
using ExaminationSystem.Mediators.Questions;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels;
using ExaminationSystem.ViewModels.Exam;
using ExaminationSystem.ViewModels.Question;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QuestioninationSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionMediator _questionMediator;

        public QuestionController(IQuestionMediator questionMediator)
        {
            _questionMediator = questionMediator;
        }

        [HttpGet("{id}")]
        public async Task<ResultViewModel<QuestionViewModel>> GetQuestionByID(int id)
        {
            var question = (await _questionMediator.GetById(id)).MapOne<QuestionViewModel>();

            return new ResultViewModel<QuestionViewModel>
            {
                IsSuccess = true,
                Data = question,
            };
        }

        [Authorize(Roles = "Instructor")]
        [HttpPost]
        public async Task<ResultViewModel<int>> CreateQuestion(QuestionCreateViewModel questionVM)
        {
            var questionDTO = questionVM.MapOne<QuestionCreateDTO>();
            int questionId = await _questionMediator.AddQuestion(questionDTO);

            return new ResultViewModel<int>
            {
                IsSuccess = true,
                Data = questionId,
            };
        }

        [Authorize(Roles = "Instructor")]
        [HttpPut]
        public async Task<ResultViewModel<bool>> EditQuestion(QuestionViewModel questionVM)
        {
            var questionDTO = questionVM.MapOne<QuestionDTO>();
            await _questionMediator.EditQuestion(questionDTO);

            return new ResultViewModel<bool>
            {
                IsSuccess = true
            };
        }

        [Authorize(Roles = "Instructor")]
        [HttpDelete]
        public async Task<ResultViewModel<bool>> DeleteQuestion(int id)
        {
            await _questionMediator.DeleteQuestion(id);
            
            return new ResultViewModel<bool>
            {
                IsSuccess = true
            };
        }
    }
}

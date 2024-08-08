using ExaminationSystem.DTO.Question;
using ExaminationSystem.Helpers;
using ExaminationSystem.Mediators;
using ExaminationSystem.ViewModels;
using ExaminationSystem.ViewModels.Exam;
using ExaminationSystem.ViewModels.Question;
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
        public ResultViewModel<QuestionViewModel> GetQuestionByID(int id)
        {
            var question = _questionMediator.GetById(id).MapOne<QuestionViewModel>();

            return new ResultViewModel<QuestionViewModel>
            {
                IsSuccess = true,
                Data = question,
            };
        }

        [HttpPost]
        public ResultViewModel<int> CreateQuestion(QuestionCreateViewModel questionVM)
        {
            var questionDTO = questionVM.MapOne<QuestionCreateDTO>();
            int questionId = _questionMediator.AddQuestion(questionDTO);

            return new ResultViewModel<int>
            {
                IsSuccess = true,
                Data = questionId,
            };
        }

        [HttpPut]
        public IActionResult EditQuestion(QuestionViewModel questionVM)
        {
            var questionDTO = questionVM.MapOne<QuestionDTO>();
            _questionMediator.EditQuestion(questionDTO);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteQuestion(int id)
        {
            _questionMediator.DeleteQuestion(id);
            return NoContent();
        }
    }
}

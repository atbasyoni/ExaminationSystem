using AutoMapper;
using ExaminationSystem.DTO.Question;
using ExaminationSystem.Helpers;
using ExaminationSystem.Services.Questions;
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
        private readonly IMapper _mapper;
        private readonly IQuestionService _questionService;

        public QuestionController(IMapper mapper, IQuestionService questionService)
        {
            _mapper = mapper;
            _questionService = questionService;
        }

        [HttpPost]
        public ResultViewModel<int> CreateQuestion(QuestionCreateViewModel questionVM)
        {
            var questionCreateDTO = questionVM.MapOne<QuestionCreateDTO>();
            int questionId = _questionService.Add(questionCreateDTO);

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
            _questionService.Update(questionDTO);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteQuestion(int id)
        {
            _questionService.Delete(id);
            return Ok();
        }
    }
}

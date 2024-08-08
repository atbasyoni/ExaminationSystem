using ExaminationSystem.DTO.Exam;
using ExaminationSystem.Helpers;
using ExaminationSystem.Mediators;
using ExaminationSystem.ViewModels;
using ExaminationSystem.ViewModels.Exam;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExamController : ControllerBase
    {
        private readonly IExamMediator _examMediator;

        public ExamController(IExamMediator ExamMediator)
        {
            _examMediator = ExamMediator;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<ExamViewModel>> GetAllExams()
        {
            var exams = _examMediator.GetAll().AsQueryable().Map<ExamViewModel>();

            return new ResultViewModel<IEnumerable<ExamViewModel>>
            {
                IsSuccess = true,
                Data = exams,
            };
        }

        [HttpGet("{id}")]
        public ResultViewModel<ExamViewModel> GetExamByID(int id)
        {
            var exam = _examMediator.GetById(id).MapOne<ExamViewModel>();

            return new ResultViewModel<ExamViewModel>
            {
                IsSuccess = true,
                Data = exam,
            };
        }

        [HttpPost]
        public ResultViewModel<int> CreateExam(ExamCreateViewModel examVM)
        {
            var examDTO = examVM.MapOne<ExamCreateDTO>();
            int examId = _examMediator.AddExam(examDTO);

            return new ResultViewModel<int>
            {
                IsSuccess = true,
                Data = examId,
            };
        }

        [HttpPut]
        public IActionResult EditExam(ExamViewModel examVM)
        {
            var examDTO = examVM.MapOne<ExamDTO>();
            _examMediator.EditExam(examDTO);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteExam(int id)
        {
            _examMediator.DeleteExam(id);
            return NoContent();
        }
    }
}
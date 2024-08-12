using ExaminationSystem.DTO.Exam;
using ExaminationSystem.Helpers;
using ExaminationSystem.Mediators.Exams;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels;
using ExaminationSystem.ViewModels.Exam;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ResultViewModel<IEnumerable<ExamViewModel>>> GetAllExams()
        {
            var exams = (await _examMediator.GetAll()).AsQueryable().Map<ExamViewModel>();

            return new ResultViewModel<IEnumerable<ExamViewModel>>
            {
                IsSuccess = true,
                Data = exams,
            };
        }

        [HttpGet("{id}")]
        public async Task<ResultViewModel<ExamViewModel>> GetExamByID(int id)
        {
            var exam = (await _examMediator.GetById(id)).MapOne<ExamViewModel>();

            return new ResultViewModel<ExamViewModel>
            {
                IsSuccess = true,
                Data = exam,
            };
        }

        [Authorize("Instructor")]
        [HttpPost]
        public async Task<ResultViewModel<int>> CreateExam(ExamCreateViewModel examVM)
        {
            var examDTO = examVM.MapOne<ExamCreateDTO>();
            int examId = await _examMediator.AddExam(examDTO);

            return new ResultViewModel<int>
            {
                IsSuccess = true,
                Data = examId,
            };
        }

        [Authorize("Instructor")]
        [HttpPut]
        public async Task<ResultViewModel<bool>> EditExam(ExamViewModel examVM)
        {
            var examDTO = examVM.MapOne<ExamDTO>();
            await _examMediator.EditExam(examDTO);

            return new ResultViewModel<bool>
            {
                IsSuccess = true
            };
        }

        [Authorize("Instructor")]
        [HttpDelete]
        public async Task<ResultViewModel<bool>> DeleteExam(int id)
        {
            await _examMediator.DeleteExam(id);

            return new ResultViewModel<bool>
            {
                IsSuccess = true
            };
        }

        [Authorize("Student")]
        [HttpPost]
        public async Task<ResultViewModel<bool>> TakeExam(ExamStudentCreateViewModel examStudentVM)
        {
            var examStudentDTO = examStudentVM.MapOne<ExamStudentCreateDTO>();
            var isAssigned = await _examMediator.TakeExam(examStudentDTO);

            return new ResultViewModel<bool>
            {
                IsSuccess = true,
                Data = isAssigned,
            };
        }

        public async Task<ResultViewModel<bool>> SubmitExam(ExamStudentViewModel examStudentVM)
        {
            var examStudentDTO = examStudentVM.MapOne<ExamStudentDTO>();
            bool IsSubmitted = await _examMediator.SubmitExam(examStudentDTO);

            return new ResultViewModel<bool>
            {
                IsSuccess = true,
                Data = IsSubmitted
            };

        }
    }
}
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExaminationSystem.DTO.Exam;
using ExaminationSystem.Helpers;
using ExaminationSystem.Services.Exams;
using ExaminationSystem.ViewModels;
using ExaminationSystem.ViewModels.Exam;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExamController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IExamService _examService;

        public ExamController(IMapper mapper, IExamService examService)
        {
            _mapper = mapper;
            _examService = examService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<ExamViewModel>> GetAllExams()
        {
            var exams = _examService.GetAll().AsQueryable().ProjectTo<ExamViewModel>(_mapper.ConfigurationProvider);

            return new ResultViewModel<IEnumerable<ExamViewModel>>
            {
                IsSuccess = true,
                Data = exams,
            };
        }

        [HttpGet("{id}")]
        public ResultViewModel<ExamViewModel> GetExamByID(int id)
        {
            var exam = _examService.GetByID(id).MapOne<ExamViewModel>();

            return new ResultViewModel<ExamViewModel>
            {
                IsSuccess = true,
                Data = exam,
            };
        }

        [HttpPost]
        public ResultViewModel<int> CreateExam(ExamCreateViewModel ExamVM)
        {
            var examCreateDTO = ExamVM.MapOne<ExamCreateDTO>();
            int examId = _examService.Add(examCreateDTO);
            
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
            _examService.Update(examDTO);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteExam(int id)
        {
            _examService.Delete(id);
            return Ok();
        }
    }
}
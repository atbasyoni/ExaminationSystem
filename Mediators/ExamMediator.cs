using ExaminationSystem.DTO.Exam;
using ExaminationSystem.Services.Exams;

namespace ExaminationSystem.Mediators
{
    public class ExamMediator : IExamMediator
    {
        private readonly IExamService _examService;
        private readonly IExamQuestionService _examQuestionService;

        public ExamMediator(IExamService examService, IExamQuestionService examQuestionService)
        {
            _examService = examService;
            _examQuestionService = examQuestionService;
        }

        public int AddExam(ExamCreateDTO examDTO)
        {
            int examId = _examService.Add(examDTO);

            return examId;
        }

        public void EditExam(ExamDTO examDTO)
        {
            _examService.Update(examDTO);
        }


        public void DeleteExam(int id)
        {
            var exam = _examService.GetByID(id);

            if (exam != null)
            {
                _examService.Delete(id);

                var examQuestions = _examQuestionService.Get(ci => ci.ExamID == id);

                if (examQuestions != null)
                {
                    _examQuestionService.DeleteRange(examQuestions);
                }
            }
        }

        public IEnumerable<ExamDTO> GetAll()
        {
            return _examService.GetAll();
        }

        public ExamDTO GetById(int id)
        {
            return _examService.GetByID(id);
        }
    }
}

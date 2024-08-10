using ExaminationSystem.DTO.Exam;
using ExaminationSystem.Services.Exams;

namespace ExaminationSystem.Mediators.Exams
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

        public async Task<int> AddExam(ExamCreateDTO examDTO)
        {
            int examId = await _examService.Add(examDTO);

            return examId;
        }

        public async Task EditExam(ExamDTO examDTO)
        {
            await _examService.Update(examDTO);
        }


        public async Task DeleteExam(int id)
        {
            var exam = await _examService.GetByID(id);

            if (exam != null)
            {
                await _examService.Delete(id);

                var examQuestions = await _examQuestionService.Get(ci => ci.ExamID == id);

                if (examQuestions != null)
                {
                    await _examQuestionService.DeleteRange(examQuestions);
                }
            }
        }

        public async Task<IEnumerable<ExamDTO>> GetAll()
        {
            return await _examService.GetAll();
        }

        public async Task<ExamDTO> GetById(int id)
        {
            return await _examService.GetByID(id);
        }
    }
}

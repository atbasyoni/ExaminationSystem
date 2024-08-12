using ExaminationSystem.DTO.Exam;
using ExaminationSystem.Services.Courses;
using ExaminationSystem.Services.CourseStudents;
using ExaminationSystem.Services.Exams;
using ExaminationSystem.Services.ExamStudents;

namespace ExaminationSystem.Mediators.Exams
{
    public class ExamMediator : IExamMediator
    {
        private readonly IExamService _examService;
        private readonly IExamQuestionService _examQuestionService;
        private readonly IExamStudentService _examStudentService;
        private readonly ICourseService _courseService;
        private readonly ICourseStudentService _courseStudentService;

        public ExamMediator(IExamService examService, 
            IExamQuestionService examQuestionService, 
            IExamStudentService examStudentService, 
            ICourseService courseService, 
            ICourseStudentService courseStudentService)
        {
            _examService = examService;
            _examQuestionService = examQuestionService;
            _examStudentService = examStudentService;
            _courseService = courseService;
            _courseStudentService = courseStudentService;
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

        public async Task<bool> TakeExam(ExamStudentCreateDTO examStudentDTO)
        {
            var exam = await _examService.GetByID(examStudentDTO.ExamId);

            if (exam == null)
            {
                throw new Exception("Exam Not Found.");
            }

            var course = await _courseService.GetByID(exam.CourseID);

            if (course == null)
            {
                throw new Exception("Course Not Found");
            }

            var isEnrolled = await _courseStudentService.Get(cs => cs.CourseID == course.Id && cs.StudentID == examStudentDTO.StudentId);
            
            if (!isEnrolled.Any())
            {
                throw new Exception("Student is not enrolled in the course");
            }

            if (DateTime.Now < exam.StartDate || DateTime.Now > exam.DueDate)
            {
                throw new Exception("Exam is not available at this time.");
            }

            var examStudent = await _examStudentService.GetExamStudent(examStudentDTO);

            if (examStudent == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> SubmitExam(ExamStudentDTO examStudentDTO)
        {
            var examStudent = await _examStudentService.SubmitExam(examStudentDTO);

            return true;
        }
    }
}

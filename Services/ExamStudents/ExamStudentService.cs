using ExaminationSystem.DTO.Exam;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories.Bases;
using ExaminationSystem.Services.Exams;
using ExaminationSystem.Services.Students;

namespace ExaminationSystem.Services.ExamStudents
{
    public class ExamStudentService : IExamStudentService
    {
        private readonly IExamService _examService;
        private readonly IStudentService _studentService;
        private readonly IRepository<ExamStudent> _examStudentRepository;
        private readonly IRepository<ExamAnswer> _examAnswerRepository;

        public ExamStudentService(IExamService examService, 
            IStudentService studentService, 
            IRepository<ExamStudent> examStudentRepository, 
            IRepository<ExamAnswer> examAnswerRepository)
        {
            _examService = examService;
            _studentService = studentService;
            _examStudentRepository = examStudentRepository;
            _examAnswerRepository = examAnswerRepository;
        }

        public async Task<int> AddExamStudent(ExamStudentCreateDTO examStudentDTO)
        {
            var examStudent = examStudentDTO.MapOne<ExamStudent>();
            await _examStudentRepository.AddAsync(examStudent);
            return examStudent.Id;
        }

        public async Task<ExamStudentCreateDTO> GetExamStudent(ExamStudentCreateDTO examStudentDTO)
        {
            var examStudent = await _examStudentRepository.First(es => es.ExamId == examStudentDTO.ExamId && es.StudentId == examStudentDTO.StudentId);
            return examStudent.MapOne<ExamStudentCreateDTO>();
        }

        public async Task<ExamStudentDTO> GetExamStudentById(int id)
        {
            var examStudent = await _examStudentRepository.GetByIDAsync(id);
            return examStudent.MapOne<ExamStudentDTO>();
        }

        public async Task<ExamStudentDTO> SubmitExam(ExamStudentDTO examStudentDTO)
        {
            var examStudent = await _examStudentRepository.GetByIDAsync(examStudentDTO.Id);

            if (examStudent != null && !examStudent.IsSubmitted)
            {
                examStudent.IsSubmitted = true; 
                examStudent.SubmissionDate = DateTime.Now;

                _examStudentRepository.Update(examStudent);

                foreach(var answerDTO in examStudentDTO.Answers)
                {
                    var answer = answerDTO.MapOne<ExamAnswer>();
                    await _examAnswerRepository.AddAsync(answer);
                }
                await _examStudentRepository.SaveChangesAsync();
                await _examAnswerRepository.SaveChangesAsync();
            }

            return examStudentDTO;
        }
    }
}

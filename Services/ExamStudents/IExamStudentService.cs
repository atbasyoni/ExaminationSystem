using ExaminationSystem.DTO.Exam;

namespace ExaminationSystem.Services.ExamStudents
{
    public interface IExamStudentService
    {
        Task<int> AddExamStudent(ExamStudentCreateDTO examStudentDTO);
        Task<ExamStudentCreateDTO> GetExamStudent(ExamStudentCreateDTO examStudentDTO);
        Task<ExamStudentDTO> GetExamStudentById(int id);
        Task<ExamStudentDTO> SubmitExam(ExamStudentDTO examStudentDTO);
    }
}

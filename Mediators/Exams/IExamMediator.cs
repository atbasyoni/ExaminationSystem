using ExaminationSystem.DTO.Exam;

namespace ExaminationSystem.Mediators.Exams
{
    public interface IExamMediator
    {
        Task<ExamDTO> GetById(int id);
        Task<IEnumerable<ExamDTO>> GetAll();
        Task<int> AddExam(ExamCreateDTO examDTO);
        Task DeleteExam(int id);
        Task EditExam(ExamDTO examDTO);
        Task<bool> TakeExam(ExamStudentCreateDTO examStudentDTO);
        Task<bool> SubmitExam(ExamStudentDTO examStudentDTO);
    }
}

using ExaminationSystem.DTO.Exam;
using ExaminationSystem.ViewModels.Exam;

namespace ExaminationSystem.Services.Exams
{
    public interface IExamService
    {
        Task<int> Add(ExamCreateDTO examDTO);
        Task<IEnumerable<ExamDTO>> GetAll();
        Task Update(ExamDTO examDTO);
        Task<ExamDTO> GetByID(int examID);
        Task Delete(int id);
    }
}
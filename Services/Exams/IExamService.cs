using ExaminationSystem.DTO.Exam;
using ExaminationSystem.ViewModels.Exam;

namespace ExaminationSystem.Services.Exams
{
    public interface IExamService
    {
        int Add(ExamCreateDTO examDTO);
        IEnumerable<ExamDTO> GetAll();
        ExamDTO GetByID(int examID);
    }
}
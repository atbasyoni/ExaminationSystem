using ExaminationSystem.DTO.Exam;
using ExaminationSystem.ViewModels.Exam;

namespace ExaminationSystem.Mediators
{
    public interface IExamMediator
    {
        ExamDTO GetById(int id);
        IEnumerable<ExamDTO> GetAll();
        void DeleteExam(int id);
        void EditExam(ExamDTO examDTO);
        int AddExam(ExamCreateDTO examDTO);

    }
}

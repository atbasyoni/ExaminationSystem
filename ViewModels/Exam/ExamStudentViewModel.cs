using ExaminationSystem.DTO.Exam;

namespace ExaminationSystem.ViewModels.Exam
{
    public class ExamStudentViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }

        public List<ExamAnswerDTO> Answers { get; set; }
    }
}

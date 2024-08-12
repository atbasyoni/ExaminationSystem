namespace ExaminationSystem.Models
{
    public class ExamAnswer : BaseModel
    {
        public int ExamStudentId { get; set; }
        public ExamStudent ExamStudent { get; set; }

        public int ExamQuestionId { get; set; }
        public ExamQuestion ExamQuestion { get; set; }

        public int ChoiceId { get; set; }
        public Choice Choice { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Models
{
    public class ExamQuestion
    {
        public int ID { get; set; }
        public int ExamID { get; set; }
        public Exam Exam { get; set; }

        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }
}

namespace ExaminationSystem.Models
{
    public class Exam
    {
        //[Key]
        public int ID { get; set; }

        public DateTime StartDate { get; set; }

        public int TotalGrade { get; set; }

        public Instructor Instructor { get; set; }
        public Course Course { get; set; }

        public HashSet<ExamQuestion> ExamQuestions { get; set; }
    }
}

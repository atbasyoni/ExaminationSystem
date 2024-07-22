namespace ExaminationSystem.Models
{
    public class Exam : BaseModel
    {

        public DateTime StartDate { get; set; }

        public int TotalGrade { get; set; }

       // public Instructor Instructor { get; set; }
        //public Course Course { get; set; }

        public HashSet<ExamQuestion> ExamQuestions { get; set; }
    }
}

namespace ExaminationSystem.Models
{
    public class ExamStudent : BaseModel
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public DateTime SubmissionDate { get; set; }
        public bool IsSubmitted { get; set; }
        public double Score { get; set; }

        public List<ExamAnswer> ExamAnswers { get; set; }
    }
}

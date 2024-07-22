namespace ExaminationSystem.Models
{
    public class Course : BaseModel
    {
        public string Name { get; set; }
        public int CreditHours { get; set; }

        public Instructor Instructor { get; set; }
        public HashSet<Exam> Exams { get; set; }

    }
}

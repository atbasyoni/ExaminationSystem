namespace ExaminationSystem.Models
{
    public class Course
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public int CreditHours { get; set; }

        public HashSet<Exam> Exams { get; set; }

    }
}

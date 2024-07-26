namespace ExaminationSystem.Models
{
    public class CourseStudent : BaseModel
    {
        public int CourseID { get; set; }
        public Course Course { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}

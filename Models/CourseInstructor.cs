namespace ExaminationSystem.Models
{
    public class CourseInstructor : BaseModel
    {
        public int CourseID { get; set; }
        public Course Course { get; set; }

        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }
    }
}

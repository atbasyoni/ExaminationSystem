namespace ExaminationSystem.Models
{
    public class Course : BaseModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int CreditHours { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        public List<CourseInstructor> CourseInstructors { get; set; }
        public List<CourseStudent> CourseStudents { get; set; }
        public HashSet<Exam> Exams { get; set; }
    }
}

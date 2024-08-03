using ExaminationSystem.Enums;
using ExaminationSystem.ViewModels.Instructors;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Models
{
    public class Instructor : User
    {
        public DateTime HireDate { get; set; }

        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        public List<CourseInstructor> CourseInstructors { get; set; }
        public HashSet<Exam> Exams { get; set; }
    }
}

zusing ExaminationSystem.Enums;
using ExaminationSystem.ViewModels.Instructors;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Models
{
    public class Instructor : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public DateTime HireDate { get; set; }

        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        public List<CourseInstructor> CourseInstructors { get; set; }
        public HashSet<Exam> Exams { get; set; }
    }
}

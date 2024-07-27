using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Models
{
    public class Department : BaseModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public List<Course> Courses { get; set; }
        public List<Instructor> Instructors { get; set; }
        public List<Student> Students { get; set; }
    }
}

using ExaminationSystem.ViewModels.Instructors;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Models
{
    [Table("Instructor", Schema = "HR")]
    public class Instructor : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public HashSet<Exam> Exams { get; set; }
    }
}

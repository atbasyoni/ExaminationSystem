using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Models
{
    [Table("Instructor", Schema = "HR")]
    public class Instructor
    {
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public HashSet<Exam> Exams { get; set; }

    }
}

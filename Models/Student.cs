using ExaminationSystem.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Models
{
    public class Student : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public double GPA { get; set; }


        [ForeignKey("Major")]
        public int MajorID { get; set; }
        public Department Major { get; set; }

        public int AddressID { get; set; }
        public Address Address { get; set; }

        public List<CourseStudent> CourseStudents { get; set; }
    }
}

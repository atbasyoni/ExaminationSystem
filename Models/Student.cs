using ExaminationSystem.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Models
{
    public class Student : User
    {
        public Gender Gender { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public double GPA { get; set; }


        [ForeignKey("Major")]
        public int MajorID { get; set; }
        public Department Major { get; set; }


        public List<CourseStudent> CourseStudents { get; set; }
        public List<ExamStudent> ExamStudents { get; set; }
    }
}

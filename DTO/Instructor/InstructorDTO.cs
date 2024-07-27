using ExaminationSystem.Enums;

namespace ExaminationSystem.DTO.Instructor
{
    public class InstructorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public DateTime HireDate { get; set; }

        public int DepartmentID { get; set; }

        public ICollection<int> InstructorIDs { get; set; }
    }
}

namespace ExaminationSystem.DTO.Course
{
    public class CourseCreateDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int CreditHours { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int DepartmentID { get; set; }
    }
}

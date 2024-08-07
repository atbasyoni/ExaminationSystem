﻿namespace ExaminationSystem.DTO.Department
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public ICollection<int> CourseIDs { get; set; }
        public ICollection<int> InstructorIDs { get; set; }
        public ICollection<int> StudentIDs { get; set; }
    }
}
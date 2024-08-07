﻿using ExaminationSystem.Enums;
using ExaminationSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.DTO.Student
{
    public class StudentCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public double GPA { get; set; }


        public int MajorID { get; set; }
        public int AddressID { get; set; }
        public ICollection<int> CourseIDs { get; set; }
    }
}
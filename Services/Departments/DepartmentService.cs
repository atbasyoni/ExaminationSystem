using AutoMapper;
using ExaminationSystem.DTO.Course;
using ExaminationSystem.DTO.Department;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IUserRepository<Instructor> _instructorRepository;
        private readonly IUserRepository<Student> _studentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IRepository<Department> departmentRepository, IRepository<Course> courseRepository, IUserRepository<Instructor> instructorRepository, IUserRepository<Student> studentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _courseRepository = courseRepository;
            _instructorRepository = instructorRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public DepartmentDTO Add(DepartmentCreateDTO departmentDTO)
        {
            var department = departmentDTO.MapOne<Department>();
            return _departmentRepository.Add(department).MapOne<DepartmentDTO>();
        }

        public void Delete(int id)
        {
            var department = _departmentRepository.GetByID(id);

            if(department == null) throw new KeyNotFoundException("Department not founnd!");


            var courses = _courseRepository.Get(c => c.DepartmentID == id).ToList();
            
            if (courses != null)
                _courseRepository.DeleteRange(courses);

            var instructors = _instructorRepository.Get(i => i.DepartmentID == id).ToList();

            if (instructors != null)
            {
                foreach (var instructor in instructors)
                {
                    instructor.DepartmentID = 0;
                    instructor.Department = null;
                    _instructorRepository.Update(instructor);
                }
            }

            var students = _studentRepository.Get(s => s.MajorID == id).ToList();
            
            if (students != null)
            {
                foreach (var student in students)
                {
                    student.MajorID = 0;
                    student.Major = null;
                    _studentRepository.Update(student);
                }
            }

            _departmentRepository.Delete(department);
        }

        public IEnumerable<DepartmentDTO> GetAll()
        {
            var departments = _departmentRepository.GetAll();
            return departments.Map<DepartmentDTO>();
        }

        public DepartmentDTO GetByID(int id)
        {
            var department = _departmentRepository.GetByID(id);
            var departmentDTO = department.MapOne<DepartmentDTO>();

            return departmentDTO;
        }

        public void Update(DepartmentDTO departmentDTO)
        {
            var department = _departmentRepository.GetByID(departmentDTO.Id);
            if (department == null) throw new KeyNotFoundException("Department not found!");

            department = departmentDTO.MapOne<Department>();
            _departmentRepository.Update(department);

            var courses = _courseRepository.Get(c => c.DepartmentID == departmentDTO.Id).ToList();

            foreach (var course in courses)
            {
                course.Department = department;
                _courseRepository.Update(course);
            }

            var instructors = _instructorRepository.Get(i => i.DepartmentID == departmentDTO.Id).ToList();

            foreach(var instructor in instructors)
            {
                instructor.Department = department;
                _instructorRepository.Update(instructor);
            }

            var students = _studentRepository.Get(s => s.MajorID == departmentDTO.Id).ToList();

            foreach(var student in students)
            {
                student.Major = department;
                _studentRepository.Update(student);
            }
        }
    }
}

using AutoMapper;
using ExaminationSystem.DTO.Department;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories.Bases;
using ExaminationSystem.Repositories.Users;
using ExaminationSystem.ViewModels.Department;

namespace ExaminationSystem.Mediators
{
    public class DepartmentMediator : IDepartmentMediator
    {
        //public DepartmentService(IRepository<Department> departmentRepository, IRepository<Course> courseRepository, IUserRepository<Instructor> instructorRepository, IUserRepository<Student> studentRepository, IMapper mapper)
        //{
        //    _departmentRepository = departmentRepository;
        //    _courseRepository = courseRepository;
        //    _instructorRepository = instructorRepository;
        //    _studentRepository = studentRepository;
        //    _mapper = mapper;
        //}

        //public void Delete(int id)
        //{
        //    var department = _departmentRepository.GetByID(id);

        //    if (department == null) throw new KeyNotFoundException("Department not founnd!");


        //    var courses = _courseRepository.Get(c => c.DepartmentID == id).ToList();

        //    if (courses != null)
        //        _courseRepository.DeleteRange(courses);

        //    var instructors = _instructorRepository.Get(i => i.DepartmentID == id).ToList();

        //    if (instructors != null)
        //    {
        //        foreach (var instructor in instructors)
        //        {
        //            instructor.DepartmentID = 0;
        //            instructor.Department = null;
        //            _instructorRepository.Update(instructor);
        //        }
        //    }

        //    var students = _studentRepository.Get(s => s.MajorID == id).ToList();

        //    if (students != null)
        //    {
        //        foreach (var student in students)
        //        {
        //            student.MajorID = 0;
        //            student.Major = null;
        //            _studentRepository.Update(student);
        //        }
        //    }

        //    _departmentRepository.Delete(department);
        //}

        //public void Update(DepartmentDTO departmentDTO)
        //{
        //    var department = _departmentRepository.GetByID(departmentDTO.Id);
        //    if (department == null) throw new KeyNotFoundException("Department not found!");

        //    department = departmentDTO.MapOne<Department>();
        //    _departmentRepository.Update(department);

        //    var courses = _courseRepository.Get(c => c.DepartmentID == departmentDTO.Id).ToList();

        //    foreach (var course in courses)
        //    {
        //        course.Department = department;
        //        _courseRepository.Update(course);
        //    }

        //    var instructors = _instructorRepository.Get(i => i.DepartmentID == departmentDTO.Id).ToList();

        //    foreach (var instructor in instructors)
        //    {
        //        instructor.Department = department;
        //        _instructorRepository.Update(instructor);
        //    }

        //    var students = _studentRepository.Get(s => s.MajorID == departmentDTO.Id).ToList();

        //    foreach (var student in students)
        //    {
        //        student.Major = department;
        //        _studentRepository.Update(student);
        //    }
        //}

        public void Add(DepartmentCreateViewModel departmentCreateVM)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DepartmentViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public DepartmentViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DepartmentViewModel departmentVM)
        {
            throw new NotImplementedException();
        }
    }
}

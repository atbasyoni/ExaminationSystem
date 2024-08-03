using AutoMapper;
using ExaminationSystem.DTO.Course;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;

namespace ExaminationSystem.Services.Courses
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<CourseInstructor> _courseInstructorRepository;
        private readonly IRepository<CourseStudent> _courseStudentRepository;
        private readonly IRepository<Exam> _examRepository;

        public CourseService(IRepository<Course> courseRepository, 
            IRepository<Department> departmentRepository, 
            IRepository<CourseInstructor> courseInstructorRepository, 
            IRepository<CourseStudent> courseStudentRepository, 
            IRepository<Exam> examRepository)
        {
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
            _courseInstructorRepository = courseInstructorRepository;
            _courseStudentRepository = courseStudentRepository;
            _examRepository = examRepository;
        }

        public CourseDTO Add(CourseCreateDTO courseDTO)
        {
            var course = courseDTO.MapOne<Course>();

            _courseRepository.Add(course);
            
            var department = _departmentRepository.Find(d => d.Id == courseDTO.DepartmentID, ["Courses"]);

            department.Courses.Add(course);

            _departmentRepository.Update(department);

            return course.MapOne<CourseDTO>();
        }

        public void Delete(int id)
        {
            var course = _courseRepository.GetByID(id);

            if (course != null)
            {

                var department = _departmentRepository.GetByID(course.DepartmentID);

                if (department != null)
                {
                    department.Courses.Remove(course);
                    _departmentRepository.Update(department);
                }

                var courseInstructors = _courseInstructorRepository.Get(ci => ci.CourseID == id).ToList();
                
                if(courseInstructors != null)
                {
                    _courseInstructorRepository.DeleteRange(courseInstructors);
                }

                var courseStudents = _courseStudentRepository.Get(ci => ci.CourseID == id).ToList();
                
                if (courseStudents != null)
                {
                _courseStudentRepository.DeleteRange(courseStudents);
                }

                var exams = _examRepository.Get(e => e.CourseID == id).ToList();
                if(exams != null)
                {
                    _examRepository.DeleteRange(exams);
                }
                
                _courseRepository.Delete(course);
            }
        }

        public IEnumerable<CourseDTO> GetAll()
        {
            return _courseRepository.GetAll().Map<CourseDTO>();
        }

        public CourseDTO GetByID(int id)
        {
            return _courseRepository.GetByID(id).MapOne<CourseDTO>();
        }

        public void Update(CourseDTO courseDTO)
        {
            var course = _courseRepository.GetByID(courseDTO.Id);

            if (course == null) throw new KeyNotFoundException("Course not found!");

            course = courseDTO.MapOne<Course>();
            _courseRepository.Update(course);
        }
    }
}

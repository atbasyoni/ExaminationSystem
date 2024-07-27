using AutoMapper;
using ExaminationSystem.DTO.Course;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;

namespace ExaminationSystem.Services.Courses
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<Department> departmentRepository;

        public CourseService(IRepository<Course> courseRepository, IRepository<Department> departmentRepository)
        {
            this.courseRepository = courseRepository;
            this.departmentRepository = departmentRepository;
        }

        public int Add(CourseCreateDTO courseDTO)
        {
            var course = courseDTO.MapOne<Course>();

            courseRepository.Add(course);
            courseRepository.SaveChanges();

            var department = departmentRepository.GetByID(course.DepartmentID);

            department.Courses.Add(course);
            departmentRepository.Update(department);
            departmentRepository.SaveChanges();

            return course.ID;
        }

        public void Delete(int id)
        {
            var course = courseRepository.GetByID(id);

            courseRepository.Delete(course);

            courseRepository.SaveChanges();
        }

        public IEnumerable<CourseDTO> GetAll()
        {
            return courseRepository.GetAll().Map<CourseDTO>();
        }

        public CourseDTO GetByID(int id)
        {
            return courseRepository.GetByID(id).MapOne<CourseDTO>();
        }

        public void Update(CourseDTO courseDTO)
        {
            var course = courseDTO.MapOne<Course>();
            courseRepository.Update(course);
            courseRepository.SaveChanges();
        }
    }
}

using ExaminationSystem.DTO.Course;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories.Bases;
using ExaminationSystem.Services.CourseInstructors;
using ExaminationSystem.Services.Courses;
using ExaminationSystem.Services.CourseStudents;
using ExaminationSystem.Services.Departments;
using ExaminationSystem.Services.Exams;
using ExaminationSystem.ViewModels.Course;

namespace ExaminationSystem.Mediators
{
    public class CourseMediator : ICourseMediator
    {
        private readonly ICourseService _courseService;
        private readonly ICourseInstructorService _courseInstructorService;
        private readonly ICourseStudentService _courseStudentService;
        private readonly IDepartmentService _departmentService;
        private readonly IExamService _examService;

        public CourseMediator(ICourseService courseService, 
            ICourseInstructorService courseInstructorService, 
            ICourseStudentService courseStudentService, 
            IDepartmentService departmentService, 
            IExamService examService)
        {
            _courseService = courseService;
            _courseInstructorService = courseInstructorService;
            _courseStudentService = courseStudentService;
            _departmentService = departmentService;
            _examService = examService;
        }



        //public int Add(CourseCreateDTO courseDTO)
        //{
        //    var course = courseDTO.MapOne<Course>();

        //    _courseRepository.Add(course);

        //    var department = _departmentRepository.Find(d => d.Id == courseDTO.DepartmentID, ["Courses"]);

        //    department.Courses.Add(course);

        //    _departmentRepository.Update(department);

        //    return course.Id;
        //}

        //public void Delete(int id)
        //{
        //    var course = _courseRepository.GetByID(id);

        //    if (course != null)
        //    {

        //        var department = _departmentRepository.GetByID(course.DepartmentID);

        //        if (department != null)
        //        {
        //            department.Courses.Remove(course);
        //            _departmentRepository.Update(department);
        //        }

        //        var courseInstructors = _courseInstructorRepository.Get(ci => ci.CourseID == id).ToList();

        //        if (courseInstructors != null)
        //        {
        //            _courseInstructorRepository.DeleteRange(courseInstructors);
        //        }

        //        var courseStudents = _courseStudentRepository.Get(ci => ci.CourseID == id).ToList();

        //        if (courseStudents != null)
        //        {
        //            _courseStudentRepository.DeleteRange(courseStudents);
        //        }

        //        var exams = _examRepository.Get(e => e.CourseID == id).ToList();
        //        if (exams != null)
        //        {
        //            _examRepository.DeleteRange(exams);
        //        }

        //        _courseRepository.Delete(course);
        //    }
        //}

        public void Add(CourseCreateViewModel courseCreateVM)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public CourseViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CourseViewModel courseVM)
        {
            throw new NotImplementedException();
        }
    }
}

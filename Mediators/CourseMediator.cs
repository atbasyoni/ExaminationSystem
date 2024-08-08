using ExaminationSystem.DTO.Course;
using ExaminationSystem.Services.CourseInstructors;
using ExaminationSystem.Services.Courses;
using ExaminationSystem.Services.CourseStudents;
using ExaminationSystem.Services.Departments;
using ExaminationSystem.Services.Exams;

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

        public int AddCourse(CourseCreateDTO courseDTO)
        {
           int courseId =  _courseService.Add(courseDTO);

            return courseId;
        }

        public void EditCourse(CourseDTO courseDTO)
        {
            _courseService.Update(courseDTO);
        }


        public void DeleteCourse(int id)
        {
            var course = _courseService.GetByID(id);

            if (course != null)
            {
                _courseService.Delete(id);

                var courseInstructors = _courseInstructorService.Get(ci => ci.CourseID == id);

                if (courseInstructors != null)
                {
                    _courseInstructorService.DeleteRange(courseInstructors);
                }

                var courseStudents = _courseStudentService.Get(ci => ci.CourseID == id);

                if (courseStudents != null)
                {
                    _courseStudentService.DeleteRange(courseStudents);
                }
            }
        }

        public IEnumerable<CourseDTO> GetAll()
        {
            return _courseService.GetAll();
        }

        public CourseDTO GetById(int id)
        {
            return _courseService.GetByID(id);
        }
    }
}

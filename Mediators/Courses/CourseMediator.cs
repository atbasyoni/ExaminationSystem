using ExaminationSystem.DTO.Course;
using ExaminationSystem.Services.CourseInstructors;
using ExaminationSystem.Services.Courses;
using ExaminationSystem.Services.CourseStudents;
using ExaminationSystem.Services.Departments;
using ExaminationSystem.Services.Exams;

namespace ExaminationSystem.Mediators.Courses
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

        public async Task<int> AddCourse(CourseCreateDTO courseDTO)
        {
            int courseId = await _courseService.Add(courseDTO);
            return courseId;
        }

        public async Task EditCourse(CourseDTO courseDTO)
        {
            await _courseService.Update(courseDTO);
        }


        public async Task DeleteCourse(int id)
        {
            var course = await _courseService.GetByID(id);

            if (course != null)
            {
                await _courseService.Delete(id);

                var courseInstructors = await _courseInstructorService.Get(ci => ci.CourseID == id);

                if (courseInstructors != null)
                {
                    await _courseInstructorService.DeleteRange(courseInstructors);
                }

                var courseStudents = await _courseStudentService.Get(ci => ci.CourseID == id);

                if (courseStudents != null)
                {
                    await _courseStudentService.DeleteRange(courseStudents);
                }
            }
        }

        public async Task<IEnumerable<CourseDTO>> GetAll()
        {
            return await _courseService.GetAll();
        }

        public async Task<CourseDTO> GetById(int id)
        {
            return await _courseService.GetByID(id);
        }
    }
}

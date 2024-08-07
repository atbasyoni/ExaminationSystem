using ExaminationSystem.DTO.Student;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories.Users;
using ExaminationSystem.Helpers;

namespace ExaminationSystem.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IUserRepository<Student> _studentRepository;

        public StudentService(IUserRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void Add(StudentCreateDTO studentDTO)
        {
            var student = studentDTO.MapOne<Student>();
            _studentRepository.Add(student);
            _studentRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            var Student = _studentRepository.GetByID(id);
            _studentRepository.Delete(Student);
            _studentRepository.SaveChanges();
        }

        public IEnumerable<StudentDTO> GetAll()
        {
            return _studentRepository.GetAll().Map<StudentDTO>();
        }

        public StudentDTO GetByID(int id)
        {
            return _studentRepository.GetByID(id).MapOne<StudentDTO>();
        }

        public void Update(StudentDTO StudentDTO)
        {
            var student = StudentDTO.MapOne<Student>();
            _studentRepository.Update(student);
            _studentRepository.SaveChanges();
        }
    }
}

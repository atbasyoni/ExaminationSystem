using ExaminationSystem.DTO.Student;

namespace ExaminationSystem.Services.Students
{
    public interface IStudentService
    {
        void Add(StudentCreateDTO studentDTO);
        IEnumerable<StudentDTO> GetAll();
        StudentDTO GetByID(int id);
        void Update(StudentDTO studentDTO);
        void Delete(int id);
    }
}

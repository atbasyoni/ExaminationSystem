using ExaminationSystem.DTO.Course;
using ExaminationSystem.DTO.Instructor;

namespace ExaminationSystem.Services.Instructors
{
    public interface IInstructorService
    {
        void Add(InstructorCreateDTO instructorDTO);
        IEnumerable<InstructorDTO> GetAll();
        InstructorDTO GetByID(int id);
        void Update(InstructorDTO instructorDTO);
        void Delete(int id);
    }
}

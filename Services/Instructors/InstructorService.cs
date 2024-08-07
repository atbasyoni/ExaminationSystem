using ExaminationSystem.DTO.Instructor;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories.Users;
using ExaminationSystem.Services.Departments;

namespace ExaminationSystem.Services.Instructors
{
    public class InstructorService : IInstructorService
    {
        private readonly IUserRepository<Instructor> _instructorRepository;

        public InstructorService(IUserRepository<Instructor> instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public void Add(InstructorCreateDTO instructorDTO)
        {
            var instructor = instructorDTO.MapOne<Instructor>();
            _instructorRepository.Add(instructor);
            _instructorRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            var instructor = _instructorRepository.GetByID(id);
            _instructorRepository.Delete(instructor);
            _instructorRepository.SaveChanges();
        }

        public IEnumerable<InstructorDTO> GetAll()
        {
            return _instructorRepository.GetAll().Map<InstructorDTO>();
        }

        public InstructorDTO GetByID(int id)
        {
            return _instructorRepository.GetByID(id).MapOne<InstructorDTO>();
        }

        public void Update(InstructorDTO instructorDTO)
        {
            var instructor = instructorDTO.MapOne<Instructor>();
            _instructorRepository.Update(instructor);
            _instructorRepository.SaveChanges();
        }
    }
}

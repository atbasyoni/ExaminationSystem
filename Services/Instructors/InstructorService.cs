using ExaminationSystem.DTO.Instructor;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.Services.Departments;

namespace ExaminationSystem.Services.Instructors
{
    public class InstructorService : IInstructorService
    {
        private readonly IUserRepository<Instructor> instructorRepository;

        public InstructorService(IUserRepository<Instructor> instructorRepository)
        {
            this.instructorRepository = instructorRepository;
        }

        public void Add(InstructorCreateDTO instructorDTO)
        {
            var instructor = instructorDTO.MapOne<Instructor>();
            instructorRepository.Add(instructor);
        }

        public void Delete(int id)
        {
            var instructor = instructorRepository.GetByID(id);
            instructorRepository.Delete(instructor);
        }

        public IEnumerable<InstructorDTO> GetAll()
        {
            return instructorRepository.GetAll().Map<InstructorDTO>();
        }

        public InstructorDTO GetByID(int id)
        {
            return instructorRepository.GetByID(id).MapOne<InstructorDTO>();
        }

        public void Update(InstructorDTO instructorDTO)
        {
            var instructor = instructorDTO.MapOne<Instructor>();
            instructorRepository.Update(instructor);
        }
    }
}

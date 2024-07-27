using ExaminationSystem.DTO.Instructor;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.Services.Departments;

namespace ExaminationSystem.Services.Instructors
{
    public class InstructorService : IInstructorService
    {
        private readonly IRepository<Instructor> instructorRepository;
        private readonly IRepository<Department> departmentRepository;

        public InstructorService(IRepository<Instructor> instructorRepository, IRepository<Department> departmentRepository)
        {
            this.instructorRepository = instructorRepository;
            this.departmentRepository = departmentRepository;
        }

        public int Add(InstructorCreateDTO instructorDTO)
        {
            var instructor = instructorDTO.MapOne<Instructor>();
            instructorRepository.Add(instructor);
            instructorRepository.SaveChanges();

            var department = departmentRepository.GetByID(instructorDTO.DepartmentID);
            department.Instructors.Add(instructor);
            departmentRepository.SaveChanges();

            return instructor.ID;
        }

        public void Delete(int id)
        {
            var instructor = instructorRepository.GetByID(id);
            instructorRepository.Delete(instructor);
            instructorRepository.SaveChanges();
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
            instructorRepository.SaveChanges();
        }
    }
}

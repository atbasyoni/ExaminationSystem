using ExaminationSystem.Data;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace ExaminationSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InstructorController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<InstructorViewModel> GetAll()
        {
            Context context = new Context();

            return context.Instructors
                .Select(x => new InstructorViewModel { FName = x.FirstName, LName = x.LastName})
                .ToList();
        }

        [HttpGet]
        public Instructor GetByID(int id)
        {
            Context context = new Context();

            return context.Instructors.Where(x => x.ID == id).FirstOrDefault();
        }
    }
}

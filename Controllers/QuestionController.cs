using ExaminationSystem.Data;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace ExaminationSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class QuestionController : ControllerBase
    {
        //[HttpGet]
        //public IEnumerable<InstructorViewModel> GetAll()
        //{
        //    Context context = new Context();

        //    return context.Instructors
        //        .Select(x => new InstructorViewModel { FName = x.FirstName, LName = x.LastName})
        //        .ToList();
        //}

        [HttpGet]
        public Question GetByID(int id)
        {
            Context context = new Context();

            Question qst = context.Questions.Where(x => x.ID == id)
                .Include(q => q.Choices)
                .FirstOrDefault();

            return qst;
        }
    }
}

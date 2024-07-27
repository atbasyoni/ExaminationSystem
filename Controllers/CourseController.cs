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
    public class CourseController : ControllerBase
    {
        //[HttpGet]
        //public IEnumerable<InstructorViewModel> GetAll()
        //{
        //    Context context = new Context();

        //    return context.Instructors
        //        .Select(x => new InstructorViewModel { FName = x.FirstName, LName = x.LastName})
        //        .ToList();
        //}

        //[HttpGet]
        //public Course GetByID(int id)
        //{
        //    Context context = new Context();

            
        //    Course qst = context.Courses.Where(x => x.ID == id)
        //        .Include(c => c.Instructor)
        //        .Include(c => c.Exams)
        //        .ThenInclude(ex => ex.ExamQuestions)
        //        .FirstOrDefault();
            

        //    Course qst = context.Courses.Where(x => x.ID == id).FirstOrDefault();

        //    return qst;
        //}
    }
}

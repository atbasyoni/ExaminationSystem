using ExaminationSystem.Data;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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
            InstructorRepository instructorRepository = new InstructorRepository();

            //IEnumerable<Instructor> instructors = instructorRepository.GetAll();

            //IEnumerable<InstructorViewModel> result = 
            //    instructorRepository.Get(x => x.ID < 100)
            //    .Select(x => new InstructorViewModel { FName = x.FirstName, LName = x.LastName }); ;

            IEnumerable<InstructorViewModel> result =
                instructorRepository.Get<InstructorViewModel>(x => x.ID < 100,
                x => new InstructorViewModel { FName = x.FirstName, LName = x.LastName });

            //instructors = instructors.Where(x => x.ID < 100);

            //IEnumerable<InstructorViewModel> result =
            //    instructors.Select(x => new InstructorViewModel { FName = x.FirstName, LName = x.LastName });

            //foreach (var item in result)
            //{
            //    Debug.WriteLine(item.FullName);
            //}

            return result;


            //List<InstructorViewModel> result = new List<InstructorViewModel>();

            //foreach (var item in query)
            //{
            //    Debug.WriteLine(item.FullName);
            //    result.Add(item);
            //}

            //return result;
        }

        [HttpGet]
        public InstructorViewModel GetByID(int id)
        {
            InstructorRepository instructorRepository = new InstructorRepository();

            var instructor = instructorRepository.GetByID(id);

            return new InstructorViewModel
            {
                FName = instructor.FirstName,
                LName = instructor.LastName,
            };
        }
    }
}

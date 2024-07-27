using ExaminationSystem.Data;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.ViewModels.Instructors;
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
        //[HttpGet]
        //public IEnumerable<InstructorViewModel> GetAll()
        //{
        //    IRepository<Instructor> instructorRepository = new Repository<Instructor>();

        //    //IEnumerable<Instructor> instructors = instructorRepository.GetAll();

        //    IEnumerable<InstructorViewModel> result =
        //        instructorRepository.Get(x => x.ID < 100)
        //        .ToViewModels();

        //IEnumerable<InstructorViewModel> result =
        //    instructorRepository.Get<InstructorViewModel>(x => x.ID < 100,
        //    x => new InstructorViewModel { FName = x.FirstName, LName = x.LastName });

        //    //instructors = instructors.Where(x => x.ID < 100);

        //    //IEnumerable<InstructorViewModel> result =
        //    //    instructors.Select(x => new InstructorViewModel { FName = x.FirstName, LName = x.LastName });

        //    //foreach (var item in result)
        //    //{
        //    //    Debug.WriteLine(item.FullName);
        //    //}

        //    return result;


        //    //List<InstructorViewModel> result = new List<InstructorViewModel>();

        //    //foreach (var item in query)
        //    //{
        //    //    Debug.WriteLine(item.FullName);
        //    //    result.Add(item);
        //    //}

        //    //return result;
        //}

        //[HttpGet]
        //public InstructorViewModel GetByID(int id)
        //{
        //    IRepository<Instructor> instructorRepository = new Repository<Instructor>();

        //    var instructor = instructorRepository.GetByID(id);

        //    return instructor.ToViewModel();
        //}

        //[HttpPut]
        //public bool Update(InstructorCreateViewModel viewModel)
        //{
        //    IRepository<Instructor> repository = new Repository<Instructor>();

        //    var instructor = repository.GetWithTrackinByID(viewModel.ID);

        //    instructor.FirstName = viewModel.FName;
        //    instructor.LastName = viewModel.LName;

        //    //repository.Update(instructor);
        //    repository.SaveChanges();

        //    return true;
        //}

    }
}
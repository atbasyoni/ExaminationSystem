using ExaminationSystem.Data;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.Services.Exams;
using ExaminationSystem.ViewModels;
using ExaminationSystem.ViewModels.Exam;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace ExaminationSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExamController : ControllerBase
    {
        IExamService examService;

        public ExamController(IExamService examService)
        {
            this.examService = examService;
        }

        [HttpPost]
        public bool Post(ExamCreateViewModel viewModel)
        {
            examService.Add(viewModel);
            
            return true;
        }
    }
}

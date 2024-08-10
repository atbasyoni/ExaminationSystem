using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExaminationSystem.DTO.Choice;
using ExaminationSystem.Helpers;
using ExaminationSystem.Mediators.Choices;
using ExaminationSystem.Models;
using ExaminationSystem.Services.Choices;
using ExaminationSystem.ViewModels;
using ExaminationSystem.ViewModels.Choices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChoiceinationSystem.Controllers
{
    [Authorize("Instructor")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class ChoiceController : ControllerBase
    {
        private readonly IChoiceMediator _choiceMediator;

        public ChoiceController(IChoiceMediator choiceMediator)
        {
            _choiceMediator = choiceMediator;
        }


        [HttpGet("{id}")]
        public async Task<ResultViewModel<ChoiceViewModel>> GetChoiceByID(int id)
        {
            var choice = (await _choiceMediator.GetById(id)).MapOne<ChoiceViewModel>();

            return new ResultViewModel<ChoiceViewModel>
            {
                IsSuccess = true,
                Data = choice,
            };
        }

        [HttpPost]
        public async Task<ResultViewModel<int>> CreateChoice(ChoiceCreateViewModel choiceVM)
        {
            var choiceCreateDTO = choiceVM.MapOne<ChoiceCreateDTO>();
            int choiceId = await _choiceMediator.AddChoice(choiceCreateDTO);

            return new ResultViewModel<int>
            {
                IsSuccess = true,
                Data = choiceId,
            };
        }

        [HttpPut]
        public async Task<ResultViewModel<bool>> EditChoice(ChoiceViewModel choiceVM)
        {
            var choiceDTO = choiceVM.MapOne<ChoiceDTO>();
            await _choiceMediator.EditChoice(choiceDTO);

            return new ResultViewModel<bool>
            {
                IsSuccess = true
            };
        }

        [HttpDelete]
        public async Task<ResultViewModel<bool>> DeleteChoice(int id)
        {
            await _choiceMediator.DeleteChoice(id);
            
            return new ResultViewModel<bool>
            {
                IsSuccess = true
            };
        }
    }
}

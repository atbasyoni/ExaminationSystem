using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExaminationSystem.DTO.Choice;
using ExaminationSystem.Helpers;
using ExaminationSystem.Services.Choices;
using ExaminationSystem.ViewModels;
using ExaminationSystem.ViewModels.Choices;
using Microsoft.AspNetCore.Mvc;

namespace ChoiceinationSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ChoiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IChoiceService _choiceService;

        public ChoiceController(IMapper mapper, IChoiceService choiceService)
        {
            _mapper = mapper;
            _choiceService = choiceService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<ChoiceViewModel>> GetAllChoices()
        {
            var choices = _choiceService.GetAll().AsQueryable().ProjectTo<ChoiceViewModel>(_mapper.ConfigurationProvider);

            return new ResultViewModel<IEnumerable<ChoiceViewModel>>
            {
                IsSuccess = true,
                Data = choices,
            };
        }

        [HttpGet("{id}")]
        public ResultViewModel<ChoiceViewModel> GetChoiceByID(int id)
        {
            var choice = _choiceService.GetByID(id).MapOne<ChoiceViewModel>();

            return new ResultViewModel<ChoiceViewModel>
            {
                IsSuccess = true,
                Data = choice,
            };
        }

        [HttpPost]
        public ResultViewModel<int> CreateChoice(ChoiceCreateViewModel choiceVM)
        {
            var choiceCreateDTO = choiceVM.MapOne<ChoiceCreateDTO>();
            int choiceId = _choiceService.Add(choiceCreateDTO);

            return new ResultViewModel<int>
            {
                IsSuccess = true,
                Data = choiceId,
            };
        }

        [HttpPut]
        public IActionResult EditChoice(ChoiceViewModel choiceVM)
        {
            var choiceDTO = choiceVM.MapOne<ChoiceDTO>();
            _choiceService.Update(choiceDTO);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteChoice(int id)
        {
            _choiceService.Delete(id);
            return Ok();
        }
    }
}

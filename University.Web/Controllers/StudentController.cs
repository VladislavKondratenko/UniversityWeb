using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using University.Services;
using University.Services.Dto;
using University.Services.Interfaces;
using University.Web.Models.ViewModels.StudentViewModels;

namespace University.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IService<StudentDto> _service;

        public StudentController(IMapper mapper, IService<StudentDto> service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<ActionResult> Index(int groupId)
        {
            var model = await PrepareIndexViewModelAsync(groupId);

            return View(model);
        }

        public async Task<ActionResult> Details(int id)
        {
            var model = await PrepareViewModelAsync<StudentDetailsViewModel>(id);

            return View(model);
        }

        public ActionResult Create(int groupId, int courseId)
        {
            var model = new StudentCreateViewModel {GroupId = groupId, CourseId = courseId};

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(StudentCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var modelDto = _mapper.Map<StudentDto>(model);
            await _service.CreateAsync(modelDto);

            return RedirectToAction(nameof(Index), new {groupId = model.GroupId});
        }

        public async Task<ActionResult> IfStudentAlreadyExist(int id)
        {
            var courseDto = await _service.GetByIdAsync(id);
            var viewModel = _mapper.Map<StudentCreateViewModel>(courseDto);
            ModelState.AddModelError("FirstName", "There is one and the same student among them");

            return View("~/Views/Student/Create.cshtml", viewModel);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var model = await PrepareViewModelAsync<StudentEditViewModel>(id);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(StudentEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var modelDto = _mapper.Map<StudentDto>(model);
            await _service.EditAsync(modelDto);

            return RedirectToAction(nameof(Index), new {groupId = model.GroupId});
        }

        public async Task<ActionResult> Delete(int id)
        {
            var model = await PrepareViewModelAsync<StudentDeleteViewModel>(id);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(StudentDeleteViewModel model)
        {
            var modelDto = _mapper.Map<StudentDto>(model);
            await _service.DeleteAsync(modelDto);

            return IsModelEmpty(await PrepareIndexViewModelAsync(model.GroupId))
                ? RedirectToAction(nameof(Index), "Group", new {courseId = modelDto.CourseId})
                : RedirectToAction(nameof(Index), "Student", new {groupId = model.GroupId});
        }

        public async Task<ActionResult> VerifyNameForCreating(string firstName, string lastName)
        {
            var name = JoinName(firstName, lastName);

            if (await _service.VerifyNameAsync(name))
                return Json(true);

            return Json($"A student named {name} already exists.");
        }

        public async Task<ActionResult> VerifyNameForEditing(string firstName, string lastName, int id)
        {
            var name = JoinName(firstName, lastName);

            if (await _service.VerifyNameAsync(name, id))
                return Json(true);

            return Json($"A student named {name} already exists.");
        }

        private static string JoinName(string firstName, string lastName)
        {
            return string.Join(StudentService.Separator, firstName, lastName);
        }

        private async Task<IEnumerable<StudentIndexViewModel>> PrepareIndexViewModelAsync(int groupId)
        {
            var listOfModelsDto = await _service.GetListAsync(groupId);

            return _mapper.Map<IEnumerable<StudentIndexViewModel>>(listOfModelsDto);
        }

        private async Task<TViewModel> PrepareViewModelAsync<TViewModel>(int id)
        {
            var modelDto = await _service.GetByIdAsync(id);

            return _mapper.Map<TViewModel>(modelDto);
        }

        private static bool IsModelEmpty(IEnumerable<StudentBaseViewModel> model)
        {
            return !model.Any();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using University.Services.Dto;
using University.Services.Interfaces;
using University.Web.Models.ViewModels.GroupsViewModels;

namespace University.Web.Controllers
{
    public class GroupController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IService<GroupDto> _service;

        public GroupController(IMapper mapper, IService<GroupDto> service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<ActionResult> Index(int courseId)
        {
            var model = await PrepareIndexViewModelAsync(courseId);

            return ModelIsEmpty(model) ? RedirectToAction("Create", new {courseId}) : View(model);
        }

        private static bool ModelIsEmpty(IEnumerable<GroupIndexViewModel> model)
        {
            return !model.Any();
        }

        public async Task<ActionResult> Details(int id)
        {
            var modelView = await PrepareModelViewAsync<GroupDetailsViewModel>(id);

            return View(modelView);
        }

        public ActionResult Create(int courseId)
        {
            var model = new GroupCreateViewModel {CourseId = courseId};

            return View(model);
        }

        public async Task<ActionResult> IfGroupExist(int id)
        {
            var courseDto = await _service.GetByIdAsync(id);
            var viewModel = _mapper.Map<GroupCreateViewModel>(courseDto);
            ModelState.AddModelError("Name", "There is the same name among the groups");

            return View("~/Views/Group/Create.cshtml", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(GroupCreateViewModel groupView)
        {
            if (!ModelState.IsValid)
                return View();

            var group = _mapper.Map<GroupDto>(groupView);
            await _service.CreateAsync(group);

            return RedirectToAction(nameof(Index), new {courseId = groupView.CourseId});
        }

        public async Task<ActionResult> Edit(int id)
        {
            var modelView = await PrepareModelViewAsync<GroupEditViewModel>(id);

            return View(modelView);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(GroupEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var modelDto = _mapper.Map<GroupDto>(model);
            await _service.EditAsync(modelDto);

            return RedirectToAction(nameof(Index), new {courseId = model.CourseId});
        }

        public async Task<ActionResult> Delete(int id)
        {
            var model = await PrepareModelViewAsync<GroupDeleteViewModel>(id);

            if (model.NumberStudents != 0)
                ModelState.AddModelError("NumberStudents", "You can't delete this group if there are students");

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(GroupDeleteViewModel model)
        {
            var modelDto = _mapper.Map<GroupDto>(model);
            await _service.DeleteAsync(modelDto);

            return RedirectToAction(nameof(Index), new {courseId = model.CourseId});
        }

        public async Task<ActionResult> VerifyNameForCreating(string name)
        {
            if (await _service.VerifyNameAsync(name))
                return Json(true);

            return Json($"A group named {name} already exists.");
        }

        public async Task<ActionResult> VerifyNameForEditing(string name, int id)
        {
            if (await _service.VerifyNameAsync(name, id))
                return Json(true);

            return Json($"A group named {name} already exists.");
        }

        private async Task<IEnumerable<GroupIndexViewModel>> PrepareIndexViewModelAsync(int courseId)
        {
            var listOfModelsDto = await _service.GetListAsync(courseId);

            return _mapper.Map<IEnumerable<GroupIndexViewModel>>(listOfModelsDto);
        }

        private async Task<TViewModel> PrepareModelViewAsync<TViewModel>(int id)
        {
            var modelDto = await _service.GetByIdAsync(id);

            return _mapper.Map<TViewModel>(modelDto);
        }
    }
}
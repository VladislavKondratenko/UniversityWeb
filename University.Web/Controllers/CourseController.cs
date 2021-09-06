using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using University.Services.Dto;
using University.Services.Interfaces;
using University.Web.Models.ViewModels.CoursesViewModels;

namespace University.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IService<CourseDto> _service;

        public CourseController(IService<CourseDto> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<ActionResult> Index()
        {
            var model = await PrepareIndexViewModelAsync();

            return IsModelEmpty(model) ? RedirectToAction("Create") : View(model);
        }

        public async Task<ActionResult> Details(int id)
        {
            var viewModel = await PrepareViewModelAsync<CourseDetailsViewModel>(id);

            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View(new CourseCreateViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(CourseCreateViewModel modelFromView)
        {
            if (!ModelState.IsValid)
                return View();

            var modelDto = _mapper.Map<CourseDto>(modelFromView);
            await _service.CreateAsync(modelDto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(int id)
        {
            var viewModel = await PrepareViewModelAsync<CourseEditViewModel>(id);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CourseEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var modelDto = _mapper.Map<CourseDto>(model);
            await _service.EditAsync(modelDto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int id)
        {
            var viewModel = await PrepareViewModelAsync<CourseDeleteViewModel>(id);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(CourseDeleteViewModel model)
        {
            var modelDto = _mapper.Map<CourseDto>(model);
            await _service.DeleteAsync(modelDto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> VerifyNameForCreating(string name)
        {
            if (await _service.VerifyNameAsync(name))
                return Json(true);

            return Json($"A course named {name} already exists.");
        }

        public async Task<ActionResult> VerifyNameForEditing(string name, int id)
        {
            if (await _service.VerifyNameAsync(name, id))
                return Json(true);

            return Json($"A course named {name} already exists.");
        }

        private static bool IsModelEmpty(IEnumerable<CourseIndexViewModel> model)
        {
            return !model.Any();
        }

        private async Task<IEnumerable<CourseIndexViewModel>> PrepareIndexViewModelAsync()
        {
            var listOfModelsDto = await _service.GetListAsync();

            return _mapper.Map<IEnumerable<CourseIndexViewModel>>(listOfModelsDto);
        }

        private async Task<TViewModel> PrepareViewModelAsync<TViewModel>(int id)
        {
            var modelDto = await _service.GetByIdAsync(id);

            return _mapper.Map<TViewModel>(modelDto);
        }
    }
}
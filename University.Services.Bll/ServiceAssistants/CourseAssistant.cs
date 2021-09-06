using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using University.Domain.Core;
using University.Infrastructure.Interfaces;
using University.Services.Dto;
using University.Services.Interfaces;

namespace University.Services.ServiceAssistants
{
    public class CourseAssistant : IAssistant<CourseDto>
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Group> _groupRepository;
        private readonly IMapper _mapper;

        public CourseAssistant(IMapper mapper, IRepository<Course> courseRepo, IRepository<Group> groupRepo)
        {
            _mapper = mapper;
            _courseRepository = courseRepo;
            _groupRepository = groupRepo;
        }

        public async Task CreateAsync(CourseDto model)
        {
            var modelCourse = _mapper.Map<Course>(model);

            await _courseRepository.CreateAsync(modelCourse);
        }

        public async Task DeleteAsync(CourseDto modelDto)
        {
            var model = _mapper.Map<Course>(modelDto);
            await _courseRepository.DeleteAsync(model);
        }

        public async Task<CourseDto> FindAsync(CourseDto modelDto)
        {
            var course = await _courseRepository.FindAsync(c =>
                c.Name == modelDto.Name && (modelDto.Id == null || c.Id != modelDto.Id));

            return _mapper.Map<CourseDto>(course);
        }

        public async Task EditAsync(CourseDto model)
        {
            var modelCourse = _mapper.Map<Course>(model);

            await _courseRepository.EditAsync(modelCourse);
        }

        public async Task<CourseDto> GetByIdAsync(int id)
        {
            var courseDomainModel = await _courseRepository.GetByIdAsync(id);
            var courseDtoModel = _mapper.Map<CourseDto>(courseDomainModel);

            courseDtoModel.NumberGroups = await CountGroupsAsync(id);

            return courseDtoModel;
        }

        public async Task<IEnumerable<CourseDto>> GetListAsync()
        {
            var listDomainModelsOfAllCourses = await _courseRepository.GetListAsync();
            var listModelsDtoOfAllCourses = _mapper.Map<IEnumerable<CourseDto>>(listDomainModelsOfAllCourses);

            return await CountGroupsAsync(listModelsDtoOfAllCourses);
        }

        public Task<IEnumerable<CourseDto>> GetListAsync(int upperLayerId)
        {
            throw new NotImplementedException();
        }

        private async Task<int> CountGroupsAsync(int courseId)
        {
            var listOfAllGroups = await _groupRepository.GetListAsync();

            return listOfAllGroups.Count(g => g.CourseId == courseId);
        }

        private async Task<IEnumerable<CourseDto>> CountGroupsAsync(IEnumerable<CourseDto> courses)
        {
            var listOfGroups = await _groupRepository.GetListAsync();

            foreach (var course in courses)
                course.NumberGroups = listOfGroups.Count(s => s.CourseId == course.Id);

            return courses;
        }
    }
}
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
    public class GroupAssistant : IAssistant<GroupDto>
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Group> _groupRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Student> _studentRepository;

        public GroupAssistant(IMapper mapper,
            IRepository<Course> courseRepo,
            IRepository<Group> groupRepo,
            IRepository<Student> studentRepo)
        {
            _mapper = mapper;
            _courseRepository = courseRepo;
            _groupRepository = groupRepo;
            _studentRepository = studentRepo;
        }

        public async Task CreateAsync(GroupDto modelDto)
        {
            var modelGroup = _mapper.Map<Group>(modelDto);
            await _groupRepository.CreateAsync(modelGroup);
        }

        public async Task DeleteAsync(GroupDto modelDto)
        {
            var model = _mapper.Map<Group>(modelDto);
            await _groupRepository.DeleteAsync(model);
        }

        public async Task<GroupDto> FindAsync(GroupDto modelDto)
        {
            var group = await _groupRepository.FindAsync(g =>
                g.Name == modelDto.Name && (modelDto.Id == null || g.Id == modelDto.Id));

            return _mapper.Map<GroupDto>(group);
        }

        public async Task EditAsync(GroupDto modelDto)
        {
            await ChangeCourseIdAsync(modelDto);

            var model = _mapper.Map<Group>(modelDto);

            await _groupRepository.EditAsync(model);
        }

        public async Task<IEnumerable<GroupDto>> GetListAsync()
        {
            var listOfModels = await _groupRepository.GetListAsync();
            var listOfModelsDto = _mapper.Map<IEnumerable<GroupDto>>(listOfModels);
            await FillEmptyPropertyAsync(listOfModelsDto);

            return listOfModelsDto;
        }

        public async Task<IEnumerable<GroupDto>> GetListAsync(int upperLayerId)
        {
            var listAllGroup = await GetListAsync();

            return listAllGroup.Where(g => g.CourseId == upperLayerId);
        }

        public async Task<GroupDto> GetByIdAsync(int id)
        {
            var listOfGroups = await GetListAsync();

            return listOfGroups.FirstOrDefault(g => g.Id == id);
        }

        private async Task FillEmptyPropertyAsync(IEnumerable<GroupDto> modelsDto)
        {
            foreach (var model in modelsDto)
                await FillEmptyPropertyAsync(model);
        }

        private async Task FillEmptyPropertyAsync(GroupDto modelDto)
        {
            await FillNumberStudentsAsync(modelDto);
            await FillCoursesNameAsync(modelDto);
            await FillListOfCoursesNamesAsync(modelDto);
        }

        private async Task FillNumberStudentsAsync(GroupDto modelDto)
        {
            var listOfStudents = await _studentRepository.GetListAsync();

            modelDto.NumberStudents = listOfStudents.Count(g => g.GroupId == modelDto.Id);
        }

        private async Task FillCoursesNameAsync(GroupDto modelDto)
        {
            var listOfCourses = await _courseRepository.GetListAsync();
            modelDto.CourseName = listOfCourses.FirstOrDefault(c => c.Id == modelDto.CourseId)?.Name;
        }

        private async Task FillListOfCoursesNamesAsync(GroupDto modelDto)
        {
            var listOfCourses = await _courseRepository.GetListAsync();
            modelDto.ListOfCoursesNames = listOfCourses.Select(c => c.Name);
        }

        private async Task ChangeCourseIdAsync(GroupDto modelDto)
        {
            var listOfCourses = await _courseRepository.GetListAsync();
            modelDto.CourseId = listOfCourses.FirstOrDefault(c => c.Name == modelDto.CourseName)?.Id;
        }
    }
}
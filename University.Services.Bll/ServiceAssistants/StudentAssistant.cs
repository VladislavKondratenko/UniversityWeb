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
    public class StudentAssistant : IAssistant<StudentDto>
    {
        private readonly IRepository<Group> _groupRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Student> _studentRepository;

        public StudentAssistant(IMapper mapper, IRepository<Student> studentRepo, IRepository<Group> groupRepo)
        {
            _mapper = mapper;
            _groupRepository = groupRepo;
            _studentRepository = studentRepo;
        }

        public async Task CreateAsync(StudentDto modelDto)
        {
            var modelStudent = _mapper.Map<Student>(modelDto);
            await _studentRepository.CreateAsync(modelStudent);
        }

        public async Task DeleteAsync(StudentDto modelDto)
        {
            var model = _mapper.Map<Student>(modelDto);
            await _studentRepository.DeleteAsync(model);
        }

        public async Task<StudentDto> FindAsync(StudentDto modelDto)
        {
            var student = await _studentRepository.FindAsync(s =>
                s.FirstName == modelDto.FirstName &&
                s.LastName == modelDto.FirstName &&
                (modelDto.Id == null || s.Id == modelDto.Id));

            return _mapper.Map<StudentDto>(student);
        }

        public async Task EditAsync(StudentDto modelDto)
        {
            await ChangeGroupsIdAsync(modelDto);

            var model = _mapper.Map<Student>(modelDto);

            await _studentRepository.EditAsync(model);
        }

        public async Task<IEnumerable<StudentDto>> GetListAsync()
        {
            var listOfModels = await _studentRepository.GetListAsync();
            var listOfModelsDto = _mapper.Map<IEnumerable<StudentDto>>(listOfModels);

            await FillEmptyPropertyAsync(listOfModelsDto);

            return listOfModelsDto;
        }

        public async Task<IEnumerable<StudentDto>> GetListAsync(int upperLayerId)
        {
            var listAllStudent = await _studentRepository.GetListAsync();
            var studentsOfGroup = listAllStudent.Where(g => g.GroupId == upperLayerId);
            var listOfModelDto = _mapper.Map<IEnumerable<StudentDto>>(studentsOfGroup);

            await FillEmptyPropertyAsync(listOfModelDto);

            return listOfModelDto;
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var listOfGroups = await GetListAsync();

            return listOfGroups.FirstOrDefault(g => g.Id == id);
        }

        private async Task ChangeGroupsIdAsync(StudentDto modelDto)
        {
            var listOfGroups = await _groupRepository.GetListAsync();
            modelDto.GroupId = listOfGroups.FirstOrDefault(g => g.Name == modelDto.GroupName)?.Id;
        }

        private async Task FillEmptyPropertyAsync(IEnumerable<StudentDto> ModelsDto)
        {
            foreach (var model in ModelsDto)
                await FillEmptyPropertyAsync(model);
        }

        private async Task FillEmptyPropertyAsync(StudentDto modelDto)
        {
            await FillGroupsNameAsync(modelDto);
            await FillListOfGroupsNamesAsync(modelDto);
            await FillCourseIdAsync(modelDto);
        }

        private async Task FillGroupsNameAsync(StudentDto modelDto)
        {
            var listOfCourses = await _groupRepository.GetListAsync();
            modelDto.GroupName = listOfCourses.FirstOrDefault(c => c.Id == modelDto.GroupId)?.Name;
        }

        private async Task FillListOfGroupsNamesAsync(StudentDto modelDto)
        {
            var listOfGroups = await _groupRepository.GetListAsync();
            modelDto.ListOfGroupsNames = listOfGroups.Select(c => c.Name);
        }

        private async Task FillCourseIdAsync(StudentDto modelDto)
        {
            var group = await _groupRepository.GetByIdAsync(modelDto.GroupId ?? throw new NullReferenceException());
            modelDto.CourseId = group.CourseId;
        }
    }
}
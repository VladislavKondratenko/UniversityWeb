using System.Threading.Tasks;
using University.Services.Dto;
using University.Services.Exceptions;
using University.Services.Interfaces;

namespace University.Services
{
    public class GroupService : ServiceBase<GroupDto>
    {
        public GroupService(IAssistant<GroupDto> assistant) : base(assistant)
        {
        }

        public override async Task DeleteAsync(GroupDto modelDto)
        {
            if (modelDto.NumberStudents != 0)
                throw new GroupIsNotEmptyException(modelDto.CourseId);

            await Assistant.DeleteAsync(modelDto);
        }

        public override async Task<bool> VerifyNameAsync(string name)
        {
            var groupDto = new GroupDto {Name = name};

            return await IsValidNameAsync(groupDto);
        }

        public override async Task<bool> VerifyNameAsync(string name, int id)
        {
            var groupDto = new GroupDto {Name = name, Id = id};

            return await IsValidNameAsync(groupDto);
        }

        private async Task<bool> IsValidNameAsync(GroupDto groupDto)
        {
            return null == await Assistant.FindAsync(groupDto);
        }
    }
}
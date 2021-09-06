using System.Threading.Tasks;
using University.Services.Dto;
using University.Services.Interfaces;

namespace University.Services
{
    public class CourseService : ServiceBase<CourseDto>
    {
        public CourseService(IAssistant<CourseDto> assistant) : base(assistant)
        {
        }

        public override async Task<bool> VerifyNameAsync(string name)
        {
            var courseDto = new CourseDto {Name = name};

            return await IsValidNameAsync(courseDto);
        }

        public override async Task<bool> VerifyNameAsync(string name, int id)
        {
            var courseDto = new CourseDto {Name = name, Id = id};

            return await IsValidNameAsync(courseDto);
        }

        private async Task<bool> IsValidNameAsync(CourseDto courseDto)
        {
            return null == await Assistant.FindAsync(courseDto);
        }
    }
}
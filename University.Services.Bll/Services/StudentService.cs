using System.Threading.Tasks;
using University.Services.Dto;
using University.Services.Interfaces;

namespace University.Services
{
    public class StudentService : ServiceBase<StudentDto>
    {
        public const char Separator = ' ';

        public StudentService(IAssistant<StudentDto> assistant) : base(assistant)
        {
        }

        public override async Task<bool> VerifyNameAsync(string name)
        {
            SplitName(name, out var firstName, out var lastName);

            var studentDto = new StudentDto {FirstName = firstName, LastName = lastName};

            return await IsValidNameAsync(studentDto);
        }

        public override async Task<bool> VerifyNameAsync(string name, int id)
        {
            SplitName(name, out var firstName, out var lastName);

            var studentDto = new StudentDto
            {
                FirstName = firstName,
                LastName = lastName,
                Id = id
            };

            return await IsValidNameAsync(studentDto);
        }

        private async Task<bool> IsValidNameAsync(StudentDto studentDto)
        {
            return null == await Assistant.FindAsync(studentDto);
        }

        private static void SplitName(string name, out string firstName, out string lastName)
        {
            firstName = name.Split(Separator)[0];
            lastName = name.Split(Separator)[1];
        }
    }
}
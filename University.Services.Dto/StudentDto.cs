using System.Collections.Generic;

namespace University.Services.Dto
{
    public class StudentDto : BaseModelDto
    {
        public int? GroupId { get; set; }
        public int? CourseId { get; set; }
        public string GroupName { get; set; }
        public IEnumerable<string> ListOfGroupsNames { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
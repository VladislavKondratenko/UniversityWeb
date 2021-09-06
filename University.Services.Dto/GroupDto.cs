using System.Collections.Generic;

namespace University.Services.Dto
{
    public class GroupDto : BaseModelDto
    {
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
        public IEnumerable<string> ListOfCoursesNames { get; set; }
        public string Name { get; set; }
        public int? NumberStudents { get; set; }
    }
}
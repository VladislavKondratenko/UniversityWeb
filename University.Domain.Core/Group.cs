using System.Collections.Generic;

namespace University.Domain.Core
{
    public class Group : EntityBaseModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public Course Course { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
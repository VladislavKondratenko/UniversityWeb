using System.Collections.Generic;

namespace University.Domain.Core
{
    public class Course : EntityBaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Group> Groups { get; set; }
    }
}
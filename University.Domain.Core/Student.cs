namespace University.Domain.Core
{
    public class Student : EntityBaseModel
    {
        public int GroupId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Group Group { get; set; }
    }
}
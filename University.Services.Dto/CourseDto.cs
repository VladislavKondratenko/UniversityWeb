namespace University.Services.Dto
{
    public class CourseDto : BaseModelDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? NumberGroups { get; set; }
    }
}
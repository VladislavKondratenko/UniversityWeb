using System.ComponentModel.DataAnnotations;

namespace University.Web.Models.ViewModels.CoursesViewModels
{
    public class CourseDetailsViewModel : CourseBaseViewModel
    {
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Number groups in the course")]
        public int NumberGroups { get; set; }
    }
}
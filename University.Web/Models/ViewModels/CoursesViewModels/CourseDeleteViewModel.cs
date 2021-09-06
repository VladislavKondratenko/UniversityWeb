using System.ComponentModel.DataAnnotations;

namespace University.Web.Models.ViewModels.CoursesViewModels
{
    public class CourseDeleteViewModel : CourseBaseViewModel
    {
        [Display(Name = "Number groups in the course")]
        public int NumberGroups { get; set; }
    }
}
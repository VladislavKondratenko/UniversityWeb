using System.ComponentModel.DataAnnotations;

namespace University.Web.Models.ViewModels.CoursesViewModels
{
    public class CourseEditViewModel : CourseBaseViewModel
    {
        [Required(ErrorMessage = "This parameter must be filled")]
        [Display(Name = "Discription")]
        public string Description { get; set; }
    }
}
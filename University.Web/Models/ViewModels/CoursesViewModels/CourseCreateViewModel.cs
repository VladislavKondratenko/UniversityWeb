using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace University.Web.Models.ViewModels.CoursesViewModels
{
    public class CourseCreateViewModel
    {
        [Display(Name = "Course's name")]
        [Remote(controller: "Course", action: "VerifyNameForCreating")]
        [Required(ErrorMessage = "This parameter must be filled")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "This parameter must be filled")]
        public string Description { get; set; }
    }
}
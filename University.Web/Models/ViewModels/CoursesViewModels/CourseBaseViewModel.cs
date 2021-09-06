using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace University.Web.Models.ViewModels.CoursesViewModels
{
    public abstract class CourseBaseViewModel
    {
        [Remote("VerifyNameForEditing", "Course", AdditionalFields = nameof(Name))]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Remote("VerifyNameForEditing", "Course", AdditionalFields = nameof(Id))]
        [Display(Name = "Course's name")]
        [Required(ErrorMessage = "This parameter must be filled")]
        public string Name { get; set; }
    }
}
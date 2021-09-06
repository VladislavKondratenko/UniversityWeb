using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace University.Web.Models.ViewModels.StudentViewModels
{
    public class StudentCreateViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int GroupId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CourseId { get; set; }

        [Remote("VerifyNameForCreating", "Student", AdditionalFields = nameof(LastName))]
        [Required(ErrorMessage = "This parameter must be filled")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Remote("VerifyNameForCreating", "Student", AdditionalFields = nameof(FirstName))]
        [Required(ErrorMessage = "This parameter must be filled")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
    }
}
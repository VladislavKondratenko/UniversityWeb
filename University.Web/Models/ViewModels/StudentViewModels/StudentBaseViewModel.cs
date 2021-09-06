using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace University.Web.Models.ViewModels.StudentViewModels
{
    public abstract class StudentBaseViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int GroupId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CourseId { get; set; }

        [Display(Name = "Group's name")]
        public string GroupName { get; set; }

        [Remote("VerifyNameForEditing", "Student", AdditionalFields = "LastName, Id")]
        [Required(ErrorMessage = "This parameter must be filled")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Remote("VerifyNameForEditing", "Student", AdditionalFields = "FirstName, Id")]
        [Required(ErrorMessage = "This parameter must be filled")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
    }
}
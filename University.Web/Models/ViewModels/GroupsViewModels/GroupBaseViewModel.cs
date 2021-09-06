using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace University.Web.Models.ViewModels.GroupsViewModels
{
    public abstract class GroupBaseViewModel
    {
        [Remote("VerifyNameForEditing", "Group", AdditionalFields = nameof(Name))]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "This parameter must be filled")]
        [Display(Name = "Course's name")]
        public string CourseName { get; set; }

        [Remote("VerifyNameForEditing", "Group", AdditionalFields = nameof(Id))]
        [Required(ErrorMessage = "This parameter must be filled")]
        [Display(Name = "Group's name")]
        public string Name { get; set; }
    }
}
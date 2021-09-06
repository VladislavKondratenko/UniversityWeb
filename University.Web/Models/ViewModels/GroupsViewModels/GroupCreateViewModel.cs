using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace University.Web.Models.ViewModels.GroupsViewModels
{
    public class GroupCreateViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int CourseId { get; set; }

        [Remote(controller: "Group", action: "VerifyNameForCreating")]
        [Required(ErrorMessage = "This parameter must be filled")]
        [Display(Name = "Group's name")]
        public string Name { get; set; }
    }
}
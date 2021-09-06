using System.ComponentModel.DataAnnotations;

namespace University.Web.Models.ViewModels.GroupsViewModels
{
    public class GroupDeleteViewModel : GroupBaseViewModel
    {
        [Display(Name = "Number students in the group")]
        public int NumberStudents { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace University.Web.Models.ViewModels.GroupsViewModels
{
    public class GroupEditViewModel : GroupBaseViewModel
    {
        [Display(Name = "Courses' names")]
        public IEnumerable<string> ListOfCoursesNames { get; set; }
    }
}
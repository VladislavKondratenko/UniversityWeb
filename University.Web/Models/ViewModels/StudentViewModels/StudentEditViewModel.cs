using System.Collections.Generic;

namespace University.Web.Models.ViewModels.StudentViewModels
{
    public class StudentEditViewModel : StudentBaseViewModel
    {
        public IEnumerable<string> ListOfGroupsNames { get; set; }
    }
}
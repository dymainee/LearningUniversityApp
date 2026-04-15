using Microsoft.AspNetCore.Mvc.Rendering;

namespace LearningUniversityApp.ViewModels
{
    public class StudentCreateViewModel
    {
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public DateOnly DateOfBirth { get; set; }
        public string GroupId { get; set; }
        public List<SelectListItem> Groups { get; set; }
    }
}

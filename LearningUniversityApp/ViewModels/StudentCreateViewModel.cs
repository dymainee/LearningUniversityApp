using Microsoft.AspNetCore.Mvc.Rendering;

namespace LearningUniversityApp.ViewModels
{
    public class StudentCreateViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public DateOnly DateOfBirth { get; set; }
        public int GroupId { get; set; }
        public List<SelectListItem> Groups { get; set; }
    }
}

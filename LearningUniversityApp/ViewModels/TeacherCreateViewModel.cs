using LearningUniversityApp.Models;

namespace LearningUniversityApp.ViewModels
{
    public class TeacherCreateViewModel
    {
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public DateOnly DateOfBirth { get; set; }

        public List<Subject> subjects { get; set; }
        


    }
}

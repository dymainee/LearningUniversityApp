using LearningUniversityApp.Models;

namespace LearningUniversityApp.ViewModels
{
    public class StudentFilterViewModel
    {
        public int? id_filter { get; set; }
        public string name_filter { get; set; }
        public string surname_filter { get; set; }
        public List<Student> students { get; set; }
    }
}

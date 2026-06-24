using LearningUniversityApp.Models;

namespace LearningUniversityApp.ViewModels
{
    public class GroupFilterViewModel
    {
        public int? id_filter { get; set; }
        public string title_filter { get; set; }
        public string description_filter { get; set; }
        
        public string sortField { get; set; }
        public SortOrder sortOrder { get; set; }

        public List<Models.Group> groups { get; set; }
    }
}

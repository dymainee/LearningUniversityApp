using LearningUniversityApp.Models;

namespace LearningUniversityApp.ViewModels
{
    public class UniversalViewModel
    {
        public string sortField { get; set; }
        public SortOrder sortOrder { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 2;
        public int TotalCount { get; set; }
    }
}

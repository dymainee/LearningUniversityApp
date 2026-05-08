using LearningUniversityApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LearningUniversityApp.ViewModels
{
    public class ScheduleCreateViewModel
    {
        public int Id { get; set; } //?
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public DayList Day {get; set;}
        public int LessonNumber { get; set; }
        public List<SelectListItem> LessonNumbers { get; set; }
        public List<SelectListItem> Groups { get; set; }
        public List<SelectListItem> Subjects { get; set; }
        public List<SelectListItem> Teachers { get; set; }
        public List<SelectListItem> Days { get; set; }
    }
}

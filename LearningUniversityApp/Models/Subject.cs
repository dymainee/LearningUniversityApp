namespace LearningUniversityApp.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<Schedule> Schedules { get; set; }

        public List<SubjectTeacher> SubjectTeachers { get; set; }

        public Subject() {
            this.SubjectTeachers = new List<SubjectTeacher>();
            this.Schedules = new List<Schedule>();
        }

        public Subject(string title)
        {
            Title = title;
            this.SubjectTeachers = new List<SubjectTeacher>();
            this.Schedules = new List<Schedule>();
        }
    }
}

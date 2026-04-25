namespace LearningUniversityApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public DateOnly DateOfBirth { get; set; }

        //public List<SubjectTeacher> Teachers { get; set; }

        public List<Schedule> Schedules { get; set; }

        public Teacher() {
            //this.Teachers = new List<SubjectTeacher>();
            this.Schedules = new List<Schedule>();
        }
        public Teacher(string name, string surname, int age, DateOnly dateofbirth)
        {
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = dateofbirth;
            //this.Teachers = new List<SubjectTeacher>();
            this.Schedules = new List<Schedule>();
        }
    }
}

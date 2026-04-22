namespace LearningUniversityApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public DateOnly DateOfBirth { get; set; }
        public Teacher() { }
        public Teacher(int id, string name, string surname, int age, DateOnly dateofbirth)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = dateofbirth;
        }
    }
}

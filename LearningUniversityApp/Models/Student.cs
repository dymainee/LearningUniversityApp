using System.ComponentModel.DataAnnotations;

namespace LearningUniversityApp.Models
{
    public class Student
    {
        public int Id { get;}
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public DateOnly DateOfBirth { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; } // navigation property
        public Student(){}
        public Student(string name, string surname, DateOnly dateofbirth, int groupId)
        {
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = dateofbirth;
            this.GroupId = groupId;
        }
    }
}

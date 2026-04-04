using System.ComponentModel.DataAnnotations;

namespace LearningUniversityApp.Models
{
    public class Student
    {
        public int Id { get; }

        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public int Age { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Student(){}
        public Student(int id, string name,string surname, int age, DateOnly dateofbirth) {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.DateOfBirth = dateofbirth;


           
            
        }
    }
}

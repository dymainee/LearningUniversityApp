using Microsoft.AspNetCore.Identity;

namespace LearningUniversityApp.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public DateOnly DateOfBirth { get; set; }

        public User()
        {   
        }

        public User (string name, string surname, DateOnly dateofbirth)
        {
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = dateofbirth;
        }
    }
}

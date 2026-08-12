using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningUniversityApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Key]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        public List<SubjectTeacher> SubjectTeachers { get; set; }
        public List<Schedule> Schedules { get; set; }

       

        public Teacher() {
            this.SubjectTeachers = new List<SubjectTeacher>();
            this.Schedules = new List<Schedule>();
        }
    }
}

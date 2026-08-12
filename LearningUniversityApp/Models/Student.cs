using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningUniversityApp.Models
{
    public class Student
    {
        public int Id { get;}

        [Key]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; } // navigation property

        public Student(){}
        public Student(int groupId)
        {
            this.GroupId = groupId;
        }
    }
}

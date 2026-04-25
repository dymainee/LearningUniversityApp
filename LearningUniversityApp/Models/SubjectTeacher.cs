namespace LearningUniversityApp.Models
{
    public class SubjectTeacher
    {
        public int SubjectID { get; set; }

        public int TeacherID { get; set; }

        public Subject Subject { get; set; }

        public Teacher Teacher { get; set; }

        public SubjectTeacher() { }
    }
}

namespace LearningUniversityApp.Models
{
    public class Group
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Student> students { get; set; } 


        public Group() { }

        public Group(string Title, string Description) {

            this.Id = Guid.NewGuid().ToString();
            this.Title = Title;
            this.Description = Description;
            this.students = new List<Student>();
           
        }


    }
}

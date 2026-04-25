namespace LearningUniversityApp.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }    
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public DayList Day { get; set; }


        public Schedule() {
            
        }

        public Schedule(DayList days) {
            this.Day = days;
            //this.GroupId = groupId; зачем так делать 
            //this.SubjectId = subjectId;
            //TeacherId = teacherId;
        }

    }
}

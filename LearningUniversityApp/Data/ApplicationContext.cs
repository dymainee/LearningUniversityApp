using LearningUniversityApp.Models;
using Microsoft.EntityFrameworkCore;
namespace LearningUniversityApp.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> students { get; set; } 
        public DbSet<Group> groups { get; set; }  
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Teacher> teachers { get; set; }    
        public DbSet<Schedule> schedules { get; set; }

        //public DbSet<SubjectTeacher> subjectteacher { get; set; }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            
            
        }

       
    }
}

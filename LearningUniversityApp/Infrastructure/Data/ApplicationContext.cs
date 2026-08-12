using LearningUniversityApp.Infrastructure.Data.Configuration;
using LearningUniversityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace LearningUniversityApp.Infrastructure.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Student> students { get; set; } 
        public DbSet<Group> groups { get; set; }  
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Teacher> teachers { get; set; }    
        public DbSet<Schedule> schedules { get; set; }

        public Student StudentProfile { get; set; }
        public Teacher TeacherProfile { get; set; }

        //public DbSet<SubjectTeacher> subjectteacher { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GroupConfigutation());
            modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfgiuration());
            modelBuilder.ApplyConfiguration(new SubjectTeacherConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            
            
        }
    }
}

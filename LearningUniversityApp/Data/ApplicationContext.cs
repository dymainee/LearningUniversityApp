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
            modelBuilder.Entity<Student>().HasKey(s => s.Id);

            modelBuilder.Entity<Schedule>().HasKey(s => s.Id);

            //modelBuilder.Entity<SubjectTeacher>().HasKey(s => s.Id);

            modelBuilder.Entity<Subject>().HasKey(s => s.Id);

            modelBuilder.Entity<Teacher>().HasKey(s => s.Id);

            modelBuilder.Entity<Group>().HasKey(s => s.Id);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Group)
                .WithMany(s => s.students)
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Group)
                .WithMany(s => s.schedules)
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Cascade);


        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            
            
        }

       
    }
}

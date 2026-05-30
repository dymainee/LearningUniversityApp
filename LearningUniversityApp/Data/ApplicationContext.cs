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
        

            modelBuilder.Entity<Schedule>().HasKey(s => s.Id);

            modelBuilder.Entity<Subject>().HasKey(s => s.Id);

            modelBuilder.Entity<Teacher>().HasKey(s => s.Id);

            modelBuilder.Entity<Group>().HasKey(s => s.Id);

            modelBuilder.Entity<SubjectTeacher>()
                .HasKey(st => new { st.SubjectID, st.TeacherID });

            modelBuilder.Entity<SubjectTeacher>()
                .HasOne(st => st.Subject)
                .WithMany(s => s.SubjectTeachers)
                .HasForeignKey(st => st.SubjectID);

            modelBuilder.Entity<SubjectTeacher>()
               .HasOne(st => st.Teacher)
               .WithMany(t => t.SubjectTeachers)
               .HasForeignKey(st => st.TeacherID);

          

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Group)
                .WithMany(s => s.schedules)
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Teacher>()
                .HasMany(s => s.Schedules)
                .WithOne(s => s.Teacher)
                .HasForeignKey(s => s.TeacherId);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Schedules)
                .WithOne(s => s.Subject)
                .HasForeignKey(s => s.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            
            
        }

       
    }
}

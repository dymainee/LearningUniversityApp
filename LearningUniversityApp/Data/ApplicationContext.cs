using LearningUniversityApp.Models;
using Microsoft.EntityFrameworkCore;
namespace LearningUniversityApp.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> students { get; set; } 
        public DbSet<Group> groups { get; set; }  

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasKey(s => s.Id);
            modelBuilder.Entity<Group>().HasKey(s => s.Id);
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Group)
                .WithMany(s => s.students)
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Cascade); 

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            
            
        }

       
    }
}

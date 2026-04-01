using LearningUniversityApp.Models;
using Microsoft.EntityFrameworkCore;
namespace LearningUniversityApp.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> students { get; set; } 

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasKey(s => s.Id);

               
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            
            
        }
       
    }
}

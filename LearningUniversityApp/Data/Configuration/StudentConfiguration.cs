using LearningUniversityApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningUniversityApp.Data.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
           builder.HasKey(s => s.Id);

            builder
              .HasOne(s => s.Group)
              .WithMany(s => s.students)
              .HasForeignKey(s => s.GroupId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

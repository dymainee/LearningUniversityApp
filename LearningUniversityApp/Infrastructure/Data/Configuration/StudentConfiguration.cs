using LearningUniversityApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LearningUniversityApp.Infrastructure.Data.Configuration
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
              .OnDelete(DeleteBehavior.NoAction);

            builder
             .HasOne(e => e.User)
             .WithOne()
             .HasForeignKey<Student>(e => e.UserId);
        }
    }
}

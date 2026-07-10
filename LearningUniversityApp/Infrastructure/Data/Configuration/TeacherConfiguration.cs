using LearningUniversityApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LearningUniversityApp.Infrastructure.Data.Configuration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(s => s.Id);
            builder
                .HasMany(s => s.Schedules)
                .WithOne(s => s.Teacher)
                .HasForeignKey(s => s.TeacherId);
        }
    }
}

using LearningUniversityApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LearningUniversityApp.Infrastructure.Data.Configuration
{
    public class SubjectTeacherConfiguration : IEntityTypeConfiguration<SubjectTeacher>
    {
        public void Configure(EntityTypeBuilder<SubjectTeacher> builder) {

            builder
                .HasKey(st => new { st.SubjectID, st.TeacherID });

            builder
                .HasOne(st => st.Subject)
                .WithMany(s => s.SubjectTeachers)
                .HasForeignKey(st => st.SubjectID);

            builder
               .HasOne(st => st.Teacher)
               .WithMany(t => t.SubjectTeachers)
               .HasForeignKey(st => st.TeacherID);

        }
    }
}

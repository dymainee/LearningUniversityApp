using LearningUniversityApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningUniversityApp.Data.Configuration
{
    public class GroupConfigutation : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder) { 
            builder.HasKey(x => x.Id);
        }
    }
}

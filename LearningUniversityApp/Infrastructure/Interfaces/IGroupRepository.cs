using LearningUniversityApp.Models;

namespace LearningUniversityApp.Infrastructure.Interfaces
{
    public interface IGroupRepository : IRepository<Group>
    {
        public List<Group> GetAllWithStudens();
    }
}

using LearningUniversityApp.Models;

namespace LearningUniversityApp.Infrastructure.Interfaces
{
    public interface IGroupRepository
    {
        public Group GetById(int id);
        public List<Group> GetAll();
        public void Create(Group group);

        public void Delete(int Id);
    }
}

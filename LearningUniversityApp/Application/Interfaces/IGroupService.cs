using LearningUniversityApp.Models;

namespace LearningUniversityApp.Application.Interfaces
{
    public interface IGroupService
    {
        public List<Group> GetAll(int? id_filter = null);
        public Group GetById(int id);
        public void Create(string Title, string Description);
        public void Edit(Group group);
        public void Delete(int id);
    }
}

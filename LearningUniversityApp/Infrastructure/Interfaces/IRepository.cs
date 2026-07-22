using Microsoft.EntityFrameworkCore;

namespace LearningUniversityApp.Infrastructure.Interfaces
{
    public interface IRepository<Model> where Model : class
    {
        public Model GetById(int id);
        public List<Model> GetAll();
        public void Create(Model group);
        public void Delete(int Id);
    }
}

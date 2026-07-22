using LearningUniversityApp.Infrastructure.Data;
using LearningUniversityApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LearningUniversityApp.Infrastructure.Repositories
{
    public class Repository<Model> : IRepository<Model> where Model : class
    {
        private readonly ApplicationContext _context;
        protected readonly DbSet<Model> _modelSet;
        public Repository(ApplicationContext context)
        {
            _context = context;
            _modelSet = _context.Set<Model>();
        }

        public Model GetById(int id)
        {
            return _modelSet.Find(id);
        }
        public List<Model> GetAll()
        {
            return _modelSet.ToList();
        }

        public void Create(Model model)
        {
            _modelSet.Add(model);
        }

        public void Delete(int Id)
        {
            _context.groups.Where(s => s.Id == Id).ExecuteDelete();
        }
    }
}

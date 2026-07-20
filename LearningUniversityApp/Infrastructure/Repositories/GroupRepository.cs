using LearningUniversityApp.Infrastructure.Data;
using LearningUniversityApp.Infrastructure.Interfaces;
using LearningUniversityApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningUniversityApp.Infrastructure.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private ApplicationContext _context;
        public GroupRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Group GetById(int id)
        {
            return _context.groups.First(s => s.Id == id);
        }
        public List<Group> GetAll()
        {
            return _context.groups.ToList();
        }

        public void Create(Group group)
        {
            _context.groups.Add(group);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            _context.groups.Where(s => s.Id == Id).ExecuteDelete();
        }
    }
}

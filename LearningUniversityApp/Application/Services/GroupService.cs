using LearningUniversityApp.Application.Interfaces;
using LearningUniversityApp.Infrastructure.Data;
using LearningUniversityApp.Infrastructure.Interfaces;
using LearningUniversityApp.Infrastructure.Repositories;
using LearningUniversityApp.Models;
using System.Text.RegularExpressions;

namespace LearningUniversityApp.Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly ApplicationContext _context;

        public GroupService(IGroupRepository groupRepository, ApplicationContext context)
        {
            _groupRepository = groupRepository;
            _context = context;
        }

        public Models.Group GetById(int id)
        {
            return _groupRepository.GetById(id);
        }
        public List<Models.Group> GetAll(int? id_filter = null)   
        {
            var groups = _groupRepository.GetAll();
            
            if (id_filter.HasValue)
            {
                groups = groups.Where(g => g.Id == id_filter).ToList();
            }

            return groups;
        }

        public List<Models.Group> GetAllWithStudents(int? id_filter = null)
        {
            var groups = _groupRepository.GetAllWithStudens();
            if (id_filter.HasValue)
            {
                groups = groups.Where(g => g.Id == id_filter).ToList();
               
            }
          
            return groups;
        }

        public void Create(string Title, string Description)
        {
            Models.Group new_group = new Models.Group(Title, Description);
            _groupRepository.Create(new_group);
            _context.SaveChanges();
        }

        public void Edit(Models.Group group)
        {
            Models.Group existed_group = GetAll().First(s => s.Id == group.Id);
            existed_group.Title = group.Title;
            existed_group.Description = group.Description;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _groupRepository.Delete(id);
            _context.SaveChanges(); 
        }

        
    }
}

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


        
    }
}

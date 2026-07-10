using LearningUniversityApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningUniversityApp.Interfaces
{
    public interface IStudentService
    {
        public List<Student> GetAll();
        public void Create(string name, string surname, DateOnly dateofbirth, int groupId);
    }
}

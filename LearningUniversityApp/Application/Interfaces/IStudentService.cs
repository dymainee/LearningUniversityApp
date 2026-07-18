using LearningUniversityApp.Models;
using LearningUniversityApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LearningUniversityApp.Application.Interfaces
{
    public interface IStudentService
    {
        public List<Student> GetAll();
        public Student GetById(int id);
        public void Create(string name, string surname, DateOnly dateofbirth, int groupId);
        public void Edit(int id, string name, string surname, DateOnly dateOfBirth, int groupId);
        public void Delete(int id);
    }
}

using LearningUniversityApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningUniversityApp.Interfaces
{
    public interface IStudentService
    {
        public List<Student> GetAll();
        public Student GetById(int id);
        public void Create(string name, string surname, DateOnly dateofbirth, int groupId);
        public void Edit(Student student);
        public void Delete(int id);
    }
}

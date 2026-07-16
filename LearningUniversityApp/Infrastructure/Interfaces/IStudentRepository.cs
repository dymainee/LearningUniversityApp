using LearningUniversityApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningUniversityApp.Infrastructure.Interfaces
{
    public interface IStudentRepository
    {
        public Student GetById(int id);
        public List<Student> GetAll();
        public void Create(Student student);
        public void Delete(int Id);

        public void SaveChanges();
    }
}

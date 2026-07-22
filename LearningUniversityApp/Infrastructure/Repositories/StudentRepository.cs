using LearningUniversityApp.Infrastructure.Data;
using LearningUniversityApp.Infrastructure.Interfaces;
using LearningUniversityApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningUniversityApp.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private ApplicationContext _context;

        public StudentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Student GetById(int id)
        {
            return _context.students.First(s => s.Id == id);
        }

        public List<Student> GetAll()
        {
            return _context.students.ToList();
        }

        public void Create(Student student)
        {
            _context.students.Add(student);
        }

        public void Delete(int Id)
        {
            _context.students.Where(s=>s.Id == Id).ExecuteDelete();
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}

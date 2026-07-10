using LearningUniversityApp.Infrastructure.Data;
using LearningUniversityApp.Infrastructure.Interfaces;
using LearningUniversityApp.Models;

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
            _context.SaveChanges();
        }
    }
}

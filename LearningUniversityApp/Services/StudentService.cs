using LearningUniversityApp.Data;
using LearningUniversityApp.Models;

namespace LearningUniversityApp.Services
{
    public class StudentService
    {
        private ApplicationContext _context;

        public StudentService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Student> GetAll()
        {
            return _context.students.ToList();
        }

        public void Create(string name, string surname, DateOnly dateofbirth, int groupId)
        {
            Student new_student = new Student(name, surname, dateofbirth, groupId);
            _context.students.Add(new_student);
            _context.SaveChanges();
        }

        //public Student Edit()
        //{
        //    return new Student();
        //}

        //public Student Delete()
        //{
        //    return new Student();
        //}
    }
}

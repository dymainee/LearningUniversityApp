using LearningUniversityApp.Data;
using LearningUniversityApp.Interfaces;
using LearningUniversityApp.Models;

namespace LearningUniversityApp.Services
{
    public class StudentService : IStudentService
    {
        private ApplicationContext _context;

        public StudentService(ApplicationContext context)
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

        public void Create(string name, string surname, DateOnly dateofbirth, int groupId)
        {
            Student new_student = new Student(name, surname, dateofbirth, groupId);
            _context.students.Add(new_student);
            _context.SaveChanges();
        }

        public void Edit(Student student)
        {
            Student existed_student = GetAll().First(s => s.Name == student.Name);
            existed_student.Name = student.Name;
            existed_student.Surname = student.Surname;
            existed_student.DateOfBirth = student.DateOfBirth;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Student student = GetById(id);
            _context.students.Remove(student);
            _context.SaveChanges();
        }
    }
}

using LearningUniversityApp.Application.Interfaces;
using LearningUniversityApp.Infrastructure.Data;
using LearningUniversityApp.Infrastructure.Interfaces;
using LearningUniversityApp.Models;

namespace LearningUniversityApp.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ApplicationContext _context;

        public StudentService(IStudentRepository studentRepository, ApplicationContext context)
        {
            _studentRepository = studentRepository;
            _context = context;
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public void Create(string name, string surname, DateOnly dateofbirth, int groupId)
        {
            Student new_student = new Student(name, surname, dateofbirth, groupId);
            _studentRepository.Create(new_student);
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

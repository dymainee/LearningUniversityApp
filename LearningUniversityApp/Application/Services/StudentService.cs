using LearningUniversityApp.Application.Interfaces;
using LearningUniversityApp.Infrastructure.Interfaces;
using LearningUniversityApp.Models;

namespace LearningUniversityApp.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
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
            _studentRepository.SaveChanges();
        }

        public void Edit(int id, string name, string surname, DateOnly dateOfBirth, int groupId)
        {
            Student existed_student = GetById(id);
            existed_student.Name = name;
            existed_student.Surname = surname;
            existed_student.DateOfBirth = dateOfBirth;
            existed_student.GroupId = groupId;

            _studentRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            _studentRepository.Delete(id);
            _studentRepository.SaveChanges();
        }
    }
}

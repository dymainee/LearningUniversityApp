using Microsoft.AspNetCore.Mvc;
using LearningUniversityApp.Data;
using LearningUniversityApp.Models;

namespace LearningUniversityApp.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationContext _context;

        public StudentController(ApplicationContext context)
        {
            this._context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            List<Student> students = _context.students.ToList();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(Student student)
        {
            _context.students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Student student = _context.students.First(s => s.Id == id);
            return View(student);
        }

        [HttpPost]
        public IActionResult EditPost(Student student)
        {
            Student existed_student = _context.students.First(s => s.Name == student.Name);
            existed_student.Name = student.Name;
            existed_student.Surname = student.Surname;
            existed_student.DateOfBirth = student.DateOfBirth;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            Student student = _context.students.First(s => s.Id == id);
            _context.students.Remove(student);
            _context.SaveChanges(); 
            return RedirectToAction("Index");
        }
    
    }
}

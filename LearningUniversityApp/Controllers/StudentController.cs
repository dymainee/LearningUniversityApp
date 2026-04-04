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
    }
}
